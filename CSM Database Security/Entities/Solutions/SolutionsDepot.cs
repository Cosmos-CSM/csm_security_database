using CSM_Foundation.Database;

using CSM_Foundation_Core;

using CSM_Foundation_Database.Entities.Depot;

namespace CSM_Database_Security.Entities.Solutions;


public interface ISolutionsDepot {

}

internal class SolutionsDepot
    : BDepot<Database, Solution> {

    public SolutionsDepot(Database Database, IDisposer<IEntity>? Disposer) : base(Database, Disposer) {
    }
}
