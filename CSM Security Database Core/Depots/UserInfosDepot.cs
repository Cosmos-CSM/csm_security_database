using CSM_Database_Core.Depots.Abstractions.Bases;
using CSM_Database_Core.Entities.Abstractions.Interfaces;

using CSM_Foundation_Core.Abstractions.Interfaces;

using CSM_Security_Database_Core.Depots.Abstractions.Interfaces;
using CSM_Security_Database_Core.Entities;

namespace CSM_Security_Database_Core.Depots;

/// <inheritdoc cref="IUserInfosDepot"/>
public class UserInfosDepot
    : DepotBase<SecurityDatabase, UserInfo>, IUserInfosDepot {

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    /// <param name="database">
    ///     Security database context instance.
    /// </param>
    /// <param name="disposer">
    ///     Data disposition manager context instance.
    /// </param>
    public UserInfosDepot(SecurityDatabase database, IDisposer<IEntity>? disposer)
        : base(database, disposer) {
    }
}
