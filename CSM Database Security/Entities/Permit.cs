using CSM_Database_Core.Core.Extensions;

using CSM_Security_Database_Core.Abstractions.Bases;
using CSM_Security_Database_Core.Entities.Abstractions.Interfaces;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSM_Security_Database_Core.Entities;

/// <inheritdoc cref="IPermit"/>
public class Permit
    : SecurityCatalogEntityBase, IPermit {

    public Solution Solution { get; set; } = default!;

    public Feature Feature { get; set; } = default!;

    public Action Action { get; set; } = default!;

    public ICollection<Profile> Profiles { get; set; } = [];

    public ICollection<User> Accounts { get; set; } = [];

    protected override void DesignEntity(EntityTypeBuilder etBuilder) {
        etBuilder.Link<Permit, Solution>(
                nameof(Solution),
                Required: true,
                Auto: true
            );
        etBuilder.Link<Permit, Feature>(
                nameof(Feature),
                Required: true,
                Auto: true
            );
        etBuilder.Link<Permit, Action>(
                nameof(Action),
                Required: true,
                Auto: true
            );

        etBuilder.HasIndex("ActionShadow", "SolutionShadow", "FeatureShadow");
    }
}