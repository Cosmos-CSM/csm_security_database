using CSM_Database_Core.Depots.Models;

using CSM_Security_Database_Core.Depots;
using CSM_Security_Database_Core.Entities;

using CSM_Security_Database_Testing.Abstractions.Bases;
using CSM_Security_Database_Testing.Utils;

namespace Integration_Tests.DepotsTests;

/// <summary>
///     Integration tests class for <see cref="EntityStatesDepot"/>
/// </summary>
public class EntityStatesDepotTests
    : SecurityDepotIntegrationTestsBase<EntityState, EntityStatesDepot> {

    protected override EntityState EntityFactory(string entropy) {
        return DraftUtils.EntityState();
    }



    public override async Task Update_Single_Success() {
        // Expectation
        EntityState expEntityState = await _storeManager.StoreEntityState();

        string? oldDescription = expEntityState.Description;
        expEntityState.Description = "New description";

        //Acting
        UpdateOutput<EntityState> actOutput = await _depot.Update(
                new QueryInput<EntityState, UpdateInput<EntityState>> {
                    Parameters = new UpdateInput<EntityState> {
                        Entity = expEntityState,
                    }
                }
            );

        // Asserting
        Assert.NotNull(actOutput.Original);
        Assert.Equal(oldDescription, actOutput.Original.Description);
        Assert.NotEqual(actOutput.Original.Description, actOutput.Updated.Description);
    }
}
