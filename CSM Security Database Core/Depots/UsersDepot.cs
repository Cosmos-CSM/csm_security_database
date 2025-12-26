using CSM_Database_Core.Core.Errors;
using CSM_Database_Core.Depots.Abstractions.Bases;
using CSM_Database_Core.Depots.Models;
using CSM_Database_Core.Entities.Abstractions.Interfaces;

using CSM_Foundation_Core.Abstractions.Interfaces;

using CSM_Security_Database_Core.Depots.Abstractions.Interfaces;
using CSM_Security_Database_Core.Entities;

using Microsoft.EntityFrameworkCore;

namespace CSM_Security_Database_Core.Depots;

/// <inheritdoc cref="IUsersDepot"/>
public class UsersDepot
    : DepotBase<SecurityDatabase, User>, IUsersDepot {

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    /// <param name="database">
    ///     Security database context.
    /// </param>
    /// <param name="disposer">
    ///     Data disposr context manager.
    /// </param>
    public UsersDepot(SecurityDatabase database, IDisposer<IEntity>? disposer)
        : base(database, disposer) {
    }

    public async Task<Permit[]> GetPermits(long id) {
        BatchOperationOutput<User> readOutput = await Read(
                new QueryInput<User, FilterQueryInput<User>> {
                    Parameters = new FilterQueryInput<User> {
                        Behavior = FilteringBehaviors.First,
                        Filter = (record) => record.Id == id,
                    },
                    PostProcessor = (query) => {
                        return query
                            .Include(a => a.Permits)
                            .Include(a => a.Profiles)
                                .ThenInclude(p => p.Permits);
                    },
                }
            );

        if (readOutput.Failed)
            throw readOutput.Failures[0].Exception!;

        if (readOutput.SuccessesCount <= 0)
            throw new DepotError<User>(DepotErrorEvents.UNFOUND);

        User User = readOutput.Successes[0];

        List<Permit> effectivePermits = [];

        bool VerifyEffective(Permit permit) {
            return
                permit.IsEnabled
                && permit.Feature.IsEnabled
                && permit.Action.IsEnabled
                && !effectivePermits.Any(ePermit => ePermit.Id == permit.Id);
        }


        foreach (Profile profile in User.Profiles) {
            foreach (Permit profilePermit in profile.Permits) {
                if (!VerifyEffective(profilePermit))
                    continue;

                effectivePermits.Add(profilePermit);
            }
        }

        foreach (Permit permit in User.Permits) {
            if (!VerifyEffective(permit))
                continue;

            effectivePermits.Add(permit);
        }

        return [.. effectivePermits];
    }
}
