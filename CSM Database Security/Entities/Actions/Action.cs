using CSM_Foundation_Database.Entities;
using CSM_Foundation_Database.Entities.Bases;

namespace CSM_Database_Security.Entities.Actions;

/// <summary>
///     Represents an available ecosystem action.
/// </summary>
public interface IAction
    : ICatalogEntity {

    #region Relations 

    /// <summary>
    ///     Permits data referencing this <see cref="Action"/>.
    /// </summary>
    [Relation]
    ICollection<Permit> Permits { get; set; }

    #endregion
}

/// <summary>
///     Represents an available ecosystem action.
/// </summary>
public class Action
    : Bases.BCatalogEntity, IAction {

    #region Relations

    [Relation]
    public ICollection<Permit> Permits { get; set; } = [];

    #endregion
}
