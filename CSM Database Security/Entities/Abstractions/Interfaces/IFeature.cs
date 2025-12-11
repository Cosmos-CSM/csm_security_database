using CSM_Database_Core.Core.Attributes;
using CSM_Database_Core.Entities.Abstractions.Interfaces;

namespace CSM_Security_Database_Core.Entities.Abstractions.Interfaces;

/// <summary>
///     Represents an ecosystem complex feature.
/// </summary>
public interface IFeature
    : ICatalogEntity {

    /// <summary>
    ///     Permits data.
    /// </summary>
    [EntityRelation]
    public ICollection<Permit> Permits { get; set; }
}