using CSM_Database_Core.Depots.Models;

using CSM_Security_Database_Core.Depots;
using CSM_Security_Database_Core.Entities;

using CSM_Security_Database_Testing.Abstractions.Bases;
using CSM_Security_Database_Testing.Utils;

using Microsoft.EntityFrameworkCore;

namespace Integration_Tests.DepotsTests;

/// <summary>
///     Integration tests class for <see cref="VendorsDepot"/>.
/// </summary>
public class VendorsDepotTests
    : SecurityDepotIntegrationTestsBase<Vendor, VendorsDepot> {

    protected override Vendor EntityFactory(string Entropy) {
        return DraftUtils.Vendor();
    }

    public override async Task Update_Single_Success() {
        //Expectation
        Vendor vendor = await _storeManager.StoreVendor(
                new Vendor {
                    Users = [
                            DraftUtils.User()
                        ]
                }
            );

        User exUser = await _storeManager.StoreUser();

        // Acting 
        UpdateOutput<Vendor> actOutput = await _depot.Update(
                new QueryInput<Vendor, UpdateInput<Vendor>> {
                    Parameters = new UpdateInput<Vendor> {
                        Entity = vendor,
                        Relations = new Dictionary<string, CSM_Database_Core.Depots.Models.Structs.RelationUpdate[]> {
                            {
                                nameof(Vendor.Users),
                                [
                                        new CSM_Database_Core.Depots.Models.Structs.RelationUpdate{
                                                Action = CSM_Database_Core.Depots.Models.Structs.RelationUpdateAction.ADD,
                                                Entity = exUser
                                            }
                                    ]
                            }
                        },
                    },
                    PostProcessor = (query) => {
                        return query.Include(
                                obj => obj.Users
                            );
                    }
                }
            );

        // Asserting
        Vendor? ogVendor = actOutput.Original;
        Vendor newVendor = actOutput.Updated;

        Assert.NotNull(ogVendor);
        Assert.Single(ogVendor.Users);
        Assert.Equal(2, newVendor.Users.Count);

        Assert.Contains(newVendor.Users, newVendorUser => newVendorUser.Id == exUser.Id);

    }
}