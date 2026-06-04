using CSM_Database_Core.Depots.Models;

using CSM_Security_Database_Core.Depots;
using CSM_Security_Database_Core.Entities;

using CSM_Security_Database_Testing.Abstractions.Bases;
using CSM_Security_Database_Testing.Utils;

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

        User exUser = _storeManager.StoreUser();
        vendor.Users.Add(exUser);

        // Acting 
        UpdateOutput<Vendor> actOutput = await _depot.Update(
                new QueryInput<Vendor, UpdateInput<Vendor>> {
                    Parameters = new UpdateInput<Vendor> {
                        Entity = vendor,
                    }
                }
            );

        // Asserting
        Vendor? ogVendor = actOutput.Original;
        Vendor newVendor = actOutput.Updated;

        Assert.NotNull(ogVendor);
        Assert.Equal(2, ogVendor.Users.Count);
        Assert.Equal(2, newVendor.Users.Count);

        Assert.Contains(newVendor.Users, newVendorUser => newVendorUser.Id == exUser.Id);

    }
}