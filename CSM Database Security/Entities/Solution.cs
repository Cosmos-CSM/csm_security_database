using CSM_Database_Core.Core.Attributes;
using CSM_Database_Core.Entities.Abstractions.Interfaces;

using CSM_Security_Database_Core.Abstractions.Bases;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSM_Security_Database_Core.Entities;

/// <summary>
///     Represents an item into the solutions ecosystem representing a solution identification along the ecosystem.
/// </summary>
public interface ISolution
    : INamedEntity {

    /// <summary>
    ///     Solution unique signature to reference easily the solution along operations.
    /// </summary>
    /// <remarks>
    ///     Must be unique. 
    ///     5 Fixed Length.
    /// </remarks>
    string Sign { get; set; }

    /// <summary>
    ///     Permits data.
    /// </summary>
    [EntityRelation]
    ICollection<Permit> Permits { get; set; }
}

/// <inheritdoc cref="ISolution"/>
public class Solution
    : SecurityNamedEntityBase, ISolution {

    public string Sign { get; set; } = string.Empty;

    [EntityRelation]
    public ICollection<Permit> Permits { get; set; } = [];

    protected override void DesignEntity(EntityTypeBuilder etBuilder) {
        etBuilder.Property(nameof(Sign))
            .IsFixedLength()
            .HasMaxLength(5)
            .IsRequired();

        etBuilder.HasIndex(nameof(Sign))
            .IsUnique();
    }
}
