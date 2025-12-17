using CSM_Security_Database_Core.Depots;

using CSM_Security_Database_Testing.Abstractions.Bases;
using CSM_Security_Database_Testing.Utils;

namespace Integration_Tests.DepotsTests;

/// <summary>
///     Integration tests class for <see cref="ActionsDepot"/>
/// </summary>
public class ActionsDepotTests
    : TestingSecurityDatabaseDepotBase<CSM_Security_Database_Core.Entities.Action, ActionsDepot> {


    protected override CSM_Security_Database_Core.Entities.Action EntityFactory(string entropy) {
        return DraftUtils.
    }
}
