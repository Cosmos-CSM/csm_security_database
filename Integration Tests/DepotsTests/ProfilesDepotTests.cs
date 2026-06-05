using CSM_Database_Core.Depots.Models;

using CSM_Security_Database_Core.Depots;
using CSM_Security_Database_Core.Entities;

using CSM_Security_Database_Testing.Abstractions.Bases;
using CSM_Security_Database_Testing.Utils;

namespace Integration_Tests.DepotsTests;

/// <summary>
///     Integration tests class for <see cref="ProfilesDepot"/>.
/// </summary>
public class ProfilesDepotTests
    : SecurityDepotIntegrationTestsBase<Profile, ProfilesDepot> {

    protected override Profile EntityFactory(string Entropy) {
        User user = _storeManager.StoreUser();
        Permit permit = _storeManager.StorePermit();

        return DraftUtils.Profile(
                new Profile {
                    Users = [
                            user,
                        ],
                    Permits = [
                            permit ,
                        ]
                }
            );
    }

    public override async Task Update_Single_Success() {
        // Expectation
        Profile profile = await _storeManager.StoreProfile(
                new Profile {
                    Users = [
                            DraftUtils.User(),
                        ],
                    Permits = [
                            DraftUtils.Permit(),
                        ]
                }
            );

        User exUser = _storeManager.StoreUser();
        Permit exPermit = _storeManager.StorePermit();

        profile.Users.Add(exUser);
        profile.Permits.Add(exPermit);

        // Acting 
        UpdateOutput<Profile> actOutput = await _depot.Update(
                new QueryInput<Profile, UpdateInput<Profile>> {
                    Parameters = new UpdateInput<Profile> {
                        Entity = profile,
                    }
                }
            );

        // Asserting
        Profile? ogProfile = actOutput.Original;
        Profile newProfile = actOutput.Updated;

        Assert.NotNull(ogProfile);
        Assert.Equal(2, newProfile.Users.Count);
        Assert.Equal(2, ogProfile.Users.Count);

        Assert.Contains(newProfile.Users, newProfileUser => newProfileUser.Id == exUser.Id);
        Assert.Contains(newProfile.Permits, newProfilePermit => newProfilePermit.Id == exPermit.Id);
    }
}
