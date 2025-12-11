using CSM_Database_Core.Depots.Abstractions.Bases;
using CSM_Database_Core.Entities.Abstractions.Interfaces;

using CSM_Foundation_Core.Abstractions.Interfaces;

using CSM_Security_Database_Core.Entities;
using CSM_Security_Database_Core.Entities.Abstractions.Interfaces;

namespace CSM_Security_Database_Core.Depots;


public interface ISolutionsDepot {

}

internal class SolutionsDepot
    : DepotBase<SecurityDatabase, Solution, ISolution> {

    public SolutionsDepot(SecurityDatabase Database, IDisposer<IEntity>? Disposer) : base(Database, Disposer) {
    }
}
