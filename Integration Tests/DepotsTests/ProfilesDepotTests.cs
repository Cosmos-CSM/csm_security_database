using CSM_Database_Core.Depots.Models;
using CSM_Database_Core.Depots.Models.Structs;

using CSM_Security_Database_Core.Depots;
using CSM_Security_Database_Core.Entities;

using CSM_Security_Database_Testing.Abstractions.Bases;
using CSM_Security_Database_Testing.Utils;

using Microsoft.EntityFrameworkCore;

namespace Integration_Tests.DepotsTests;

/// <summary>
///     Integration tests class for <see cref="ProfilesDepot"/>.
/// </summary>
public class ProfilesDepotTests
    : SecurityDepotIntegrationTestsBase<Profile, ProfilesDepot> {

    protected override Profile EntityFactory(string Entropy) {
        User user = _storeManager.StoreUser().GetAwaiter().GetResult();
        Permit permit = _storeManager.StorePermit().GetAwaiter().GetResult();

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

        User exUser = await _storeManager.StoreUser();
        Permit exPermit = await _storeManager.StorePermit();

        // Acting 
        UpdateOutput<Profile> actOutput = await _depot.Update(
                new QueryInput<Profile, UpdateInput<Profile>> {
                    Parameters = new UpdateInput<Profile> {
                        Entity = profile,
                        Relations = new Dictionary<string, RelationUpdate[]> {
                            {
                                nameof(Profile.Users),
                                [
                                        new RelationUpdate {
                                                Action = RelationUpdateAction.ADD,
                                                Entity = exUser
                                            }
                                    ]
                            },
                            {
                                nameof(Profile.Permits),
                                [
                                        new RelationUpdate {
                                                Action = RelationUpdateAction.ADD,
                                                Entity = exPermit
                                            }
                                    ]
                            }
                        },
                    },
                    PostProcessor = (query) => {
                        return query.Include(
                                obj => obj.Users
                            )
                            .Include(
                                obj => obj.Permits
                            );
                    }
                }
            );

        // Asserting
        Profile? ogProfile = actOutput.Original;
        Profile newProfile = actOutput.Updated;

        Assert.NotNull(ogProfile);
        Assert.Single(ogProfile.Users);
        Assert.Single(ogProfile.Permits);

        Assert.Equal(2, newProfile.Users.Count);
        Assert.Equal(2, newProfile.Permits.Count);

        Assert.Contains(newProfile.Users, newProfileUser => newProfileUser.Id == exUser.Id);
        Assert.Contains(newProfile.Permits, newProfilePermit => newProfilePermit.Id == exPermit.Id);
    }
}
