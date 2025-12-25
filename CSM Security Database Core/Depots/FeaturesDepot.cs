using CSM_Database_Core.Depots.Abstractions.Bases;
using CSM_Database_Core.Entities.Abstractions.Interfaces;

using CSM_Foundation_Core.Abstractions.Interfaces;

using CSM_Security_Database_Core.Depots.Abstractions.Interfaces;
using CSM_Security_Database_Core.Entities;

namespace CSM_Security_Database_Core.Depots;

/// <inheritdoc cref="IFeaturesDepot"/>
public class FeaturesDepot
    : DepotBase<SecurityDatabase, Feature>, IFeaturesDepot {

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    /// <param name="Database">
    ///     Security database context dependency.
    /// </param>
    /// <param name="Disposer">
    ///     Data disposition context manager.
    /// </param>
    public FeaturesDepot(SecurityDatabase Database, IDisposer<IEntity>? Disposer)
        : base(Database, Disposer) {
    }
}
