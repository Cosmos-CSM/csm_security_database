using CSM_Database_Testing.Abstractions.Bases;

using CSM_Security_Database_Core;
using CSM_Security_Database_Core.Depots;
using CSM_Security_Database_Core.Entities;

using CSM_Security_Database_Testing.Utils;

namespace Integration_Tests.DepotsTests;

/// <summary>
///     Integration tests class for <see cref="SolutionsDepot"/>.
/// </summary>
public class SolutionsDepotTests
    : TestingDepotBase<Solution, SolutionsDepot, SecurityDatabase> {

    protected override Solution EntityFactory(string Entropy) {
        return DraftUtils.Solution();
    }
}
