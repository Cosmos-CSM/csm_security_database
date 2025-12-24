using CSM_Database_Testing.Abstractions.Bases;

using CSM_Security_Database_Core;
using CSM_Security_Database_Core.Depots;
using CSM_Security_Database_Core.Entities;

using CSM_Security_Database_Testing.Utils;

namespace Integration_Tests.DepotsTests;

/// <summary>
///     Integration tests class for <see cref="FeaturesDepot"/>.
/// </summary>
public class FeaturesDepotTests
    : TestingDepotBase<Feature, FeaturesDepot, SecurityDatabase> {

    protected override Feature EntityFactory(string Entropy) {
        return DraftUtils.Feature();
    }
}
