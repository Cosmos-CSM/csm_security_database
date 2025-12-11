using CSM_Database_Core.Depots.Abstractions.Bases;
using CSM_Database_Core.Entities.Abstractions.Interfaces;

using CSM_Foundation_Core.Abstractions.Interfaces;

using CSM_Security_Database_Core.Depots.Abstractions.Interfaces;
using CSM_Security_Database_Core.Entities;

namespace CSM_Security_Database_Core.Depots;


public class ActionsDepot
    : DepotBase<SecurityDatabase, Entities.Action, IAction>,
    IActionsDepot {

    public ActionsDepot(SecurityDatabase Database, IDisposer<IEntity>? Disposer) : base(Database, Disposer) {
    }
}
