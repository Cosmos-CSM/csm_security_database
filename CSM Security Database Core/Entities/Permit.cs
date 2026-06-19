using CSM_Database_Core.Core.Attributes;
using CSM_Database_Core.Core.Extensions;

using CSM_Security_Database_Core.Abstractions.Bases;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSM_Security_Database_Core.Entities;

/// <summary>
///     Represents a permit into the ecosystem, to trace security through actions into system.
/// </summary>
public class Permit
    : SecurityCatalogEntityBase {

    /// <summary>
    ///     Solution data.
    /// </summary>
    [EntityRelation]
    public Solution Solution { get; set; } = default!;

    /// <summary>
    ///     Feature data.
    /// </summary>
    [EntityRelation]
    public Feature Feature { get; set; } = default!;

    /// <summary>
    ///     Action data.
    /// </summary>
    [EntityRelation]
    public Action Action { get; set; } = default!;

    /// <summary>
    ///     Profiles data.
    /// </summary>
    [EntityRelation]
    public ICollection<Profile> Profiles { get; set; } = [];

    /// <summary>
    ///     Users data.
    /// </summary>
    [EntityRelation]
    public ICollection<User> Users { get; set; } = [];

    /// <inheritdoc/>
    protected override void DesignEntity(EntityTypeBuilder etBuilder) {
        etBuilder.Link<Permit, Solution>(
                nameof(Solution),
                isRequired: true,
                isAutoLoaded: true
            );
        etBuilder.Link<Permit, Feature>(
                nameof(Feature),
                isRequired: true,
                isAutoLoaded: true
            );
        etBuilder.Link<Permit, Action>(
                nameof(Action),
                isRequired: true,
                isAutoLoaded: true
            );

        etBuilder.HasIndex("ActionShadow", "SolutionShadow", "FeatureShadow");
    }
}