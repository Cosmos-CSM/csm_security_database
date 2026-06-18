using CSM_Database_Core.Depots.Models;
using CSM_Database_Core.Depots.Models.Structs;

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
        Action expAction = _storeManager.StoreAction();
        //Permit expPermit = _storeManager.StorePermit();
        Permit expPermit = _storeManager.StorePermit(new Permit {
            Action = expAction
        });

        string? oldDescription = expAction.Description;
        expAction.Description = "New description";
        expAction.Permits = [
                expPermit
            ];

        UpdateOutput<Action> actOutput = await _depot.Update(
            new QueryInput<Action, UpdateInput<Action>> {
                Parameters = new UpdateInput<Action> {
                    Entity = expAction,
                }
            }
        );

        // Acting
        //UpdateOutput<Action> actOutput = await _depot.Update(
        //        new QueryInput<Action, UpdateInput<Action>> {
        //            Parameters = new UpdateInput<Action> {
        //                Entity = expAction,
        //                Relations = new Dictionary<string, RelationUpdate[]> {
        //                    {
        //                        nameof(Action.Permits),
        //                        [
        //                            new RelationUpdate {
        //                                 Entity = expPermit,
        //                                 Action = RelationUpdateAction.ADD
        //                            }
        //                        ]
        //                    }
        //                }
        //            }
        //        }    
        //    );

        // Asserting
        Assert.NotNull(actOutput.Original);
        Assert.Equal(oldDescription, actOutput.Original.Description);
        Assert.NotEqual(actOutput.Original.Description, actOutput.Updated.Description);
        Assert.NotEmpty(actOutput.Updated.Permits);
        Assert.Contains(actOutput.Updated.Permits, actUpdatedPermit => actUpdatedPermit.Id == expPermit.Id);
    }
}
