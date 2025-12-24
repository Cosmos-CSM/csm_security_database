using CSM_Database_Testing.Abstractions.Bases;

using CSM_Security_Database_Core;
using CSM_Security_Database_Core.Depots;
using CSM_Security_Database_Core.Entities;

using CSM_Security_Database_Testing.Utils;

namespace Integration_Tests.DepotsTests;

/// <summary>
///     Integration tests class for <see cref="PermitsDepot"/>.
/// </summary>
public class PermitsDepotTests
    : TestingDepotBase<Permit, PermitsDepot, SecurityDatabase> {
    protected override Permit EntityFactory(string Entropy) {
        return DraftUtils.Permit(
                new Permit {
                    Action = Store(DraftUtils.Action()),
                    Feature = Store(DraftUtils.Feature()),
                    Solution = Store(DraftUtils.Solution()),
                }
            );
    }
}
