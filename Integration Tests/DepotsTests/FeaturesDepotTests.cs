using CSM_Database_Core.Depots.Models;

using CSM_Security_Database_Core.Depots;
using CSM_Security_Database_Core.Entities;

using CSM_Security_Database_Testing.Abstractions.Bases;
using CSM_Security_Database_Testing.Utils;

namespace Integration_Tests.DepotsTests;

/// <summary>
///     Integration tests class for <see cref="FeaturesDepot"/>.
/// </summary>
public class FeaturesDepotTests
    : SecurityDepotIntegrationTestsBase<Feature, FeaturesDepot> {

    protected override Feature EntityFactory(string Entropy) {
        return DraftUtils.Feature();
    }

    public override async Task Update_Single_Success() {
        // Setting
        Feature feature = _storeManager.StoreFeature();

        // Expectations
        string? oldDescription = feature.Description;
        Permit expPermit = _storeManager.StorePermit();

        // Acting
        feature.Description = "New description random";
        feature.Permits.Add(expPermit);
        UpdateOutput<Feature> actOutput = await _depot.Update(
                new QueryInput<Feature, UpdateInput<Feature>> {
                    Parameters = new UpdateInput<Feature> {
                        Entity = feature,
                    }
                }
            );

        // Asserting
        Assert.NotNull(actOutput.Original);
        Assert.Equal(oldDescription, actOutput.Original.Description);
        Assert.NotEqual(actOutput.Original.Description, actOutput.Updated.Description);
        Assert.NotEmpty(actOutput.Updated.Permits);
        Assert.Contains(actOutput.Updated.Permits, actUpdatedPermit => actUpdatedPermit.Id == expPermit.Id);
    }
}
