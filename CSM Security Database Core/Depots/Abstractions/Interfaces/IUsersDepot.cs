using CSM_Database_Core.Depots.Abstractions.Interfaces;

using CSM_Security_Database_Core.Entities;

namespace CSM_Security_Database_Core.Depots.Abstractions.Interfaces;

/// <summary>
///     Represents an entities depot provider for <see cref="User"/>.
/// </summary>
public interface IUsersDepot
    : IDepot<User> {

    /// <summary>
    ///     Calculates the effective permits from the given <paramref name="id"/> as an <see cref="Account"/>.
    /// </summary>
    /// <param name="id">
    ///     <see cref="IEntity.Id"/> pointer identifier for the <see cref="Account"/> to calculate its effective permits.
    /// </param>
    /// <returns>
    ///     Effective <see cref="Permit"/> collection for the given <see cref="Account"/>.
    /// </returns>
    Task<Permit[]> GetPermits(long id);
}
