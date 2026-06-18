using CSM_Database_Core.Core.Attributes;

using CSM_Security_Database_Core.Abstractions.Bases;

namespace CSM_Security_Database_Core.Entities;

/// <summary>
///     Represents an ecosystem complex feature.
/// </summary>
public class Feature
    : SecurityCatalogEntityBase {

    /// <summary>
    ///     Permits data.
    /// </summary>
    [EntityDependency("Permits", typeof(Permit), isCollection: true)]
    public ICollection<Permit> Permits { get; set; } = [];
}
