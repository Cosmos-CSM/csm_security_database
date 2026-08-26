using CSM_Database_Core.Depots.Models;

using CSM_Security_Database_Core.Depots;
using CSM_Security_Database_Core.Entities;

using CSM_Security_Database_Testing.Abstractions.Bases;
using CSM_Security_Database_Testing.Utils;

namespace Integration_Tests.DepotsTests;

/// <summary>
///     Integration tests class for <see cref="CSM_Security_Database_Core.Depots.UsersDepot"/>.
/// </summary>
public class UsersDepotTests
    : SecurityDepotIntegrationTestsBase<User, UsersDepot> {

    protected override User EntityFactory(string Entropy) {
        User user = DraftUtils.User(
                new User {
                    State = _storeManager.StoreEntityState().Result,
                    UserInfo = _storeManager.StoreUserInfo().Result,
                }
            );
        return user;
    }

    public override async Task Update_Single_Success() {
        //Preparing
        User user = await _storeManager.StoreUser();
        
        //Expectations
        string oldUsername = user.Username;
        string newUsername = $"{oldUsername}_upd";
        
        //Acting
        user.Username = newUsername;
        UpdateOutput<User> actOutput = await _depot.Update(
                new QueryInput<User, UpdateInput<User>> {
                    Parameters = new UpdateInput<User> {
                        Entity = user,
                    }
                }
            );

        //Asserting
        Assert.NotNull(actOutput.Original);
        Assert.Equal(oldUsername, actOutput.Original.Username);
        Assert.Equal(newUsername, actOutput.Updated.Username);
    }
}
