using CSM_Database_Testing.Abstractions.Bases;

using CSM_Security_Database_Core;
using CSM_Security_Database_Core.Depots;
using CSM_Security_Database_Core.Entities;

using CSM_Security_Database_Testing.Utils;

namespace Integration_Tests.DepotsTests;

/// <summary>
///     Integration tests class for <see cref="ProfilesDepot"/>.
/// </summary>
public class ProfilesDepotTests
    : TestingDepotBase<Profile, ProfilesDepot, SecurityDatabase> {
    protected override Profile EntityFactory(string Entropy) {
        return DraftUtils.Profile();
    }
}
