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
        Solution solution = DraftUtils.Solution();
        solution.State = _storeManager.StoreEntityState().Result;
        return solution;
    }

    public override async Task Update_Single_Success() {
        //Expectation
        Solution solution = await _storeManager.StoreSolution();

        string? oldDescription = solution.Description;
        string newDescription = "Random description check";

        //Acting
        solution.Description = newDescription;

        // Acting
        solution.Description = newDescription;
        UpdateOutput<Solution> actOutput = await _depot.Update(
                new QueryInput<Solution, UpdateInput<Solution>> {
                    Parameters = new UpdateInput<Solution> {
                        Entity = solution,
                    }
                }
            );
        // Asserting
        Assert.NotNull(actOutput.Original);
        Assert.Equal(oldDescription, actOutput.Original.Description);
        Assert.Equal(newDescription, actOutput.Updated.Description);

    }
}
