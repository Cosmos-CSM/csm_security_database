using CSM_Database_Core.Core.Attributes;

using CSM_Security_Database_Core.Abstractions.Bases;

namespace CSM_Security_Database_Core.Entities;

/// <summary>
///     Represents an available ecosystem action.
/// </summary>
public class Action
    : SecurityCatalogEntityBase {

    /// <summary>
    ///     Permits data.
    /// </summary>
    [EntityRelation]
    public ICollection<Permit> Permits { get; set; } = [];
}
