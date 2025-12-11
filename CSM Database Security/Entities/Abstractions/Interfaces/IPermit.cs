using CSM_Database_Core.Core.Attributes;
using CSM_Database_Core.Entities.Abstractions.Interfaces;

namespace CSM_Security_Database_Core.Entities.Abstractions.Interfaces;

/// <summary>
///     Represents an ecosystem permnit.
/// </summary>
public interface IPermit
    : ICatalogEntity {

    /// <summary>
    ///     Solution information.
    /// </summary>
    [EntityRelation]
    public Solution Solution { get; set; }

    /// <summary>
    ///     Feature information.
    /// </summary>
    [EntityRelation]
    public Feature Feature { get; set; }

    /// <summary>
    ///     Action information.
    /// </summary>
    [EntityRelation]
    public Action Action { get; set; }

    /// <summary>
    ///     Profiles data.
    /// </summary>
    [EntityRelation]
    public ICollection<Profile> Profiles { get; set; }

    /// <summary>
    ///     Accounts data.
    /// </summary>
    [EntityRelation]
    public ICollection<User> Accounts { get; set; }
}
