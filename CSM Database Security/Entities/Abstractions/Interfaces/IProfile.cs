using CSM_Database_Core.Core.Attributes;
using CSM_Database_Core.Entities.Abstractions.Interfaces;

namespace CSM_Security_Database_Core.Entities.Abstractions.Interfaces;

/// <summary>
///     Represents an ecosystem profile, a collection of permits.
/// </summary>
public interface IProfile
    : ICatalogEntity {



    /// <summary>
    ///     <see cref="Permit"/> related to this <see cref="Profile"/>.
    /// </summary>
    [EntityRelation]
    public ICollection<Permit> Permits { get; set; }

    /// <summary>
    ///     <see cref="User"/> related to this <see cref="Profile"/>.
    /// </summary>
    [EntityRelation]
    public ICollection<User> Accounts { get; set; }
}
