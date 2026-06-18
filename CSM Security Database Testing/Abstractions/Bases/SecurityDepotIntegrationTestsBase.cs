using CSM_Database_Core.Depots.Abstractions.Interfaces;
using CSM_Database_Core.Entities.Abstractions.Interfaces;

using CSM_Database_Testing.Abstractions.Bases;
using CSM_Database_Testing.Disposing.Abstractions.Bases;

using CSM_Security_Database_Core;

using CSM_Security_Database_Testing.Managers;

namespace CSM_Security_Database_Testing.Abstractions.Bases;

/// <summary>
///     Represents an <see cref="SecurityDatabase"/> integration tests base for a Depot.
/// </summary>
/// <typeparam name="TEntity">
///     Type of the <see cref="IEntity"/> being handled.
/// </typeparam>
/// <typeparam name="TDepot">
///     Type of the <see cref="IDepot{TEntity}"/> being tested.
/// </typeparam>
public abstract class SecurityDepotIntegrationTestsBase<TEntity, TDepot>
    : DepotIntegrationTestsBase<TEntity, TDepot, SecurityDatabase>
    where TEntity : class, IEntity, new()
    where TDepot : class, IDepot<TEntity> {

    /// <summary>
    ///     Security testing data store manager.
    /// </summary>
    new protected readonly StoreManager _storeManager;

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    /// <param name="databaseFactory">
    ///     Main database factory 
    /// </param>
    /// <param name="databaseFactories">
    ///     Collateral used databases factories to be used, this are usually needed when the <typeparamref name="TEntity"/> used has dependencies on a different <see cref="CSM_Database_Core.Abstractions.Interfaces.IDatabase"/> source than it's own context.
    /// </param>
    protected SecurityDepotIntegrationTestsBase(DatabaseFactory? databaseFactory = null, params DatabaseFactory[] databaseFactories)
        : base(databaseFactory, databaseFactories) {

        _storeManager = new StoreManager(
                base._storeManager
            );
    }
}