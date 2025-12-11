using CSM_Security_Database_Core.Abstractions.Bases;
using CSM_Security_Database_Core.Entities.Abstractions.Interfaces;

namespace CSM_Security_Database_Core.Entities;

/// <summary>
///     Represents an ecosystem complex feature.
/// </summary>
public class Feature
    : SecurityCatalogEntityBase, IFeature {

    public ICollection<Permit> Permits { get; set; } = [];
}
