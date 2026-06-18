using CSM_Database_Core.Depots.Models;

using CSM_Security_Database_Core.Depots;
using CSM_Security_Database_Core.Entities;

using CSM_Security_Database_Testing.Abstractions.Bases;
using CSM_Security_Database_Testing.Utils;

namespace Integration_Tests.DepotsTests;

/// <summary>
///     Integration tests class for <see cref="UserInfo"/>
/// </summary>
public class UserInfosTests
    : SecurityDepotIntegrationTestsBase<UserInfo, UserInfosDepot> {

    protected override UserInfo EntityFactory(string Entropy) {
        return DraftUtils.UserInfo();
    }

    public override async Task Update_Single_Success() {
        // Setting
        UserInfo userInfo = _storeManager.StoreUserInfo();
        // Expectations
        string oldName = userInfo.Name;
        string newName = $"{oldName}_upd";
        // Acting
        userInfo.Name = newName;
        UpdateOutput<UserInfo> actOutput = await _depot.Update(
                new QueryInput<UserInfo, UpdateInput<UserInfo>> {
                    Parameters = new UpdateInput<UserInfo> {
                        Entity = userInfo,
                    }
                }
            );
        // Asserting
        Assert.NotNull(actOutput.Original);
        Assert.Equal(oldName, actOutput.Original.Name);
        Assert.Equal(newName, actOutput.Updated.Name);
    }
}
