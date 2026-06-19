using CSM_Database_Core.Depots.Models;

using CSM_Security_Database_Core.Depots;
using CSM_Security_Database_Core.Entities;

using CSM_Security_Database_Testing.Abstractions.Bases;
using CSM_Security_Database_Testing.Utils;

using Action = CSM_Security_Database_Core.Entities.Action;

namespace Integration_Tests.DepotsTests;

/// <summary>
///     Integration tests class for <see cref="ActionsDepot"/>
/// </summary>
public class ActionsDepotTests
    : SecurityDepotIntegrationTestsBase<Action, ActionsDepot> {

    protected override Action EntityFactory(string entropy) {
        return DraftUtils.Action();
    }



    public override async Task Update_Single_Success() {
        // Expectation
        Action expAction = await _storeManager.StoreAction();
        Permit expPermit = await _storeManager.StorePermit();

        string? oldDescription = expAction.Description;
        expAction.Description = "New description";

        //Acting
        UpdateOutput<Action> actOutput = await _depot.Update(
                new QueryInput<Action, UpdateInput<Action>> {
                    Parameters = new UpdateInput<Action> {
                        Entity = expAction,
                    }
                }
            );

        // Asserting
        Assert.NotNull(actOutput.Original);
        Assert.Equal(oldDescription, actOutput.Original.Description);
        Assert.NotEqual(actOutput.Original.Description, actOutput.Updated.Description);
    }
}
