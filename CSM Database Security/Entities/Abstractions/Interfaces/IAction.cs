using CSM_Database_Core.Core.Attributes;
using CSM_Database_Core.Entities.Abstractions.Interfaces;

namespace CSM_Security_Database_Core.Entities.Abstractions.Interfaces;

/// <summary>
///     Represents an available ecosystem action.
/// </summary>
public interface IAction
    : ICatalogEntity {

    /// <summary>
    ///     Permits data.
    /// </summary>
    [EntityRelation]
    ICollection<Permit> Permits { get; set; }
}
