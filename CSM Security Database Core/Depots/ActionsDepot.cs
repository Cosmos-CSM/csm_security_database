using CSM_Database_Core.Depots.Abstractions.Bases;
using CSM_Database_Core.Entities.Abstractions.Interfaces;

using CSM_Foundation_Core.Abstractions.Interfaces;

using CSM_Security_Database_Core.Depots.Abstractions.Interfaces;

namespace CSM_Security_Database_Core.Depots;

/// <inheritdoc cref="IActionsDepot"/>
public class ActionsDepot
    : DepotBase<SecurityDatabase, Entities.Action>,
    IActionsDepot {

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    /// <param name="database">
    ///     Security database context dependency.
    /// </param>
    /// <param name="disposer">
    ///     Disposer data context dependency.
    /// </param>
    public ActionsDepot(SecurityDatabase database, IDisposer<IEntity>? disposer) : base(database, disposer) {
    }
}
