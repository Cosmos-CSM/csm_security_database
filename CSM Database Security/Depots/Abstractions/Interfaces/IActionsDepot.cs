using CSM_Database_Core.Depots.Abstractions.Interfaces;

using CSM_Security_Database_Core.Entities.Abstractions.Interfaces;

namespace CSM_Security_Database_Core.Depots.Abstractions.Interfaces;


public interface IActionsDepot
    : IDepot<Entities.Action, IAction> {
}
