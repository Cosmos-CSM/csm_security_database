using CSM_Database_Core.Depots.Models;

using CSM_Security_Database_Core.Depots;
using CSM_Security_Database_Core.Entities;

using CSM_Security_Database_Testing.Abstractions.Bases;
using CSM_Security_Database_Testing.Utils;

namespace Integration_Tests.DepotsTests;

/// <summary>
///     Integration tests class for <see cref="SolutionsDepot"/>.
/// </summary>
public class SolutionsDepotTests
    : SecurityDepotIntegrationTestsBase<Solution, SolutionsDepot> {

    protected override Solution EntityFactory(string Entropy) {
        return DraftUtils.Solution();
    }

    public override async Task Update_Single_Success() {
        //Expectation
        Solution solution = _storeManager.StoreSolution();

        Permit exPermit = _storeManager.StorePermit();
        string exDescription = "Random description checl";

        //Acting
        solution.Description = exDescription;

    }
}
