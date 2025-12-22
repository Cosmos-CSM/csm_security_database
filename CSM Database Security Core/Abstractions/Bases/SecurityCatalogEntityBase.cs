
using CSM_Database_Core.Entities.Abstractions.Bases;

namespace CSM_Security_Database_Core.Abstractions.Bases;

/// <summary>
///     Represents a [CSM Security] database template base catalog entity.
/// </summary>
public class SecurityCatalogEntityBase
    : CatalogEntityBase {

    public override Type Database { get; init; } = typeof(SecurityDatabase);
}
