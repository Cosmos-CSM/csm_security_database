using CSM_Database_Core.Core.Models;

using CSM_Security_Database_Core.Depots;

using CSM_Security_Database_Testing.Abstractions.Bases;
using CSM_Security_Database_Testing.Utils;

using Action = CSM_Security_Database_Core.Entities.Action;

namespace Integration_Tests.DepotsTests;

/// <summary>
///     Integration tests class for <see cref="ActionsDepot"/>
/// </summary>
public class ActionsDepotTests
    : TestingSecurityDatabaseDepotBase<Action, ActionsDepot> {

    protected override Action EntityFactory(string entropy) {

        ConnectionOptions
        return DraftUtils.Action();
    }
}
