using CSM_Database_Core.Core.Attributes;
using CSM_Database_Core.Entities.Abstractions.Interfaces;

using CSM_Security_Database_Core.Abstractions.Bases;

namespace CSM_Security_Database_Core.Entities;

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

/// <summary>
///     Represents an available ecosystem action.
/// </summary>
public class Action
    : SecurityCatalogEntityBase, IAction {

    [EntityRelation]
    public ICollection<Permit> Permits { get; set; } = [];
}
