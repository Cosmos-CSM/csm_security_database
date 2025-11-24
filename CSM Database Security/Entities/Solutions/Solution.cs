using CSM_Foundation_Database.Entities;
using CSM_Foundation_Database.Entities.Bases;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSM_Database_Security.Entities.Solutions;

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
    ///     Related <see cref="Permit"/> data.
    /// </summary>
    [Relation]
    ICollection<Permit> Permits { get; set; }
}

/// <inheritdoc cref="ISolution"/>
public class Solution
    : Bases.BNamedEntity, ISolution {

    #region Properties

    public string Sign { get; set; } = string.Empty;

    #endregion

    #region Relations

    [Relation]
    public ICollection<Permit> Permits { get; set; } = [];

    #endregion

    protected override void DesignEntity(EntityTypeBuilder etBuilder) {
        etBuilder.Property(nameof(Sign)).IsFixedLength().HasMaxLength(5).IsRequired();
        etBuilder.HasIndex(nameof(Sign)).IsUnique();
    }
}
