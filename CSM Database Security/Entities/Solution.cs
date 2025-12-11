using System.ComponentModel.DataAnnotations;

using CSM_Database_Core.Core.Attributes;

using CSM_Security_Database_Core.Abstractions.Bases;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSM_Security_Database_Core.Entities;

/// <summary>
///     Represents a solution metadata info into the ecosystem.
/// </summary>
public class Solution
    : SecurityNamedEntityBase {

    /// <summary>
    ///     Unique solution signature.
    /// </summary>
    [StringLength(5, MinimumLength = 5)]
    public string Sign { get; set; } = string.Empty;

    /// <summary>
    ///     Permits data.
    /// </summary>
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
