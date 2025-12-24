using CSM_Database_Core.Depots.Abstractions.Bases;
using CSM_Database_Core.Entities.Abstractions.Interfaces;

using CSM_Foundation_Core.Abstractions.Interfaces;

using CSM_Security_Database_Core.Depots.Abstractions.Interfaces;
using CSM_Security_Database_Core.Entities;

namespace CSM_Security_Database_Core.Depots;

/// <inheritdoc cref="IProfilesDepot"/>
public class ProfilesDepot
    : DepotBase<SecurityDatabase, Profile>, IProfilesDepot {

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    /// <param name="Database">
    ///     Security database context.
    /// </param>
    /// <param name="Disposer">
    ///     Data disposr context manager.
    /// </param>
    public ProfilesDepot(SecurityDatabase Database, IDisposer<IEntity>? Disposer)
        : base(Database, Disposer) {
    }
}
