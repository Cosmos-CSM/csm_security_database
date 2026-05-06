using CSM_Security_Database_Core.Depots;
using CSM_Security_Database_Core.Entities;

using CSM_Security_Database_Testing.Abstractions.Bases;
using CSM_Security_Database_Testing.Utils;

namespace Integration_Tests.DepotsTests;

/// <summary>
///     Integration tests class for <see cref="User"/>
/// </summary>
public class UserInfosTests
    : SecurityDepotIntegrationTestsBase<UserInfo, UserInfosDepot> {

    protected override UserInfo EntityFactory(string Entropy) {
        return DraftUtils.UserInfo();
    }

    public override Task Update_Single_Success() {
        throw new NotImplementedException();
    }
}
