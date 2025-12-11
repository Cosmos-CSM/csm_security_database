using CSM_Database_Core.Depots.Abstractions.Interfaces;
using CSM_Database_Core.Entities.Abstractions.Interfaces;

using CSM_Database_Testing.Abstractions.Bases;
using CSM_Database_Testing.Disposing.Abstractions.Bases;

using CSM_Security_Database_Core;

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
public abstract class SecurityDepotIntegrationTestsBase<TEntityInterface, TEntity, TDepot>
    : TestingDepotBase<TEntityInterface, TEntity, TDepot, SecurityDatabase>
    where TEntityInterface : IEntity
    where TEntity : class, TEntityInterface, new()
    where TDepot : class, IDepot<TEntity, TEntityInterface> {

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    /// <param name="databaseFactory">
    ///     Main database factory 
    /// </param>
    /// <param name="databaseFactories">
    ///     Collateral used databases factories to be used, this are usually needed when the <typeparamref name="TEntity"/> used has dependencies on a different <see cref="IDatabase"/> source than it's own context.
    /// </param>
    protected SecurityDepotIntegrationTestsBase(DatabaseFactory? databaseFactory = null)
        : base(databaseFactory) {
    }
}
