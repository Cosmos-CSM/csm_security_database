using CSM_Database_Core.Depots.Models;

using CSM_Security_Database_Core.Depots;
using CSM_Security_Database_Core.Entities;

using CSM_Security_Database_Testing.Abstractions.Bases;
using CSM_Security_Database_Testing.Utils;

namespace Integration_Tests.DepotsTests;

/// <summary>
///     Integration tests class for <see cref="PermitsDepot"/>.
/// </summary>
public class PermitsDepotTests
    : SecurityDepotIntegrationTestsBase<Permit, PermitsDepot> {
    protected override Permit EntityFactory(string Entropy) {
        return DraftUtils.Permit(
                new Permit {
                    Action = Store(DraftUtils.Action()),
                    Feature = Store(DraftUtils.Feature()),
                    Solution = Store(DraftUtils.Solution()),
                }
            );
    }

    public override async Task Update_Single_Success() {
        // Expectation
        Feature exFeature = _storeManager.StoreFeature();
        Solution exSolution = _storeManager.StoreSolution();
        CSM_Security_Database_Core.Entities.Action exAction = _storeManager.StoreAction();

        Permit permit = _storeManager.StorePermit();

        permit.Action = exAction;
        permit.Feature = exFeature;
        permit.Solution = exSolution;

        // Acting
        UpdateOutput<Permit> actOutput = await _depot.Update(
                new QueryInput<Permit, UpdateInput<Permit>> {
                    Parameters = new UpdateInput<Permit> {
                        Entity = permit,
                    }
                }
            );

        // Asserting
        Permit? ogPermit = actOutput.Original;
        Permit newPermit = actOutput.Updated;

        Assert.NotNull(ogPermit);
        Assert.Equal(ogPermit.Id, permit.Id);
        Assert.Equal(ogPermit.Id, newPermit.Id);

        Assert.NotEqual(ogPermit.Action.Id, exAction.Id);
        Assert.NotEqual(ogPermit.Feature.Id, exFeature.Id);
        Assert.NotEqual(ogPermit.Solution.Id, exSolution.Id);

        Assert.Equal(newPermit.Action.Id, exAction.Id);
        Assert.Equal(newPermit.Feature.Id, exFeature.Id);
        Assert.Equal(newPermit.Solution.Id, exSolution.Id);
    }
}
