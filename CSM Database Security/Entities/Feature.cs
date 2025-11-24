using CSM_Database_Security.Bases;

using CSM_Foundation_Database.Entities;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSM_Database_Security.Entities;

/// <summary>
///     Represents an ecosystem complex feature.
/// </summary>
public interface IFeature {

    #region Properties

    bool IsEnabled { get; set; }

    #endregion

    #region Relations

    #endregion
}

/// <summary>
///     Represents an ecosystem complex feature.
/// </summary>
public class Feature
    : BNamedEntity, IFeature {

    #region Properties
    public bool IsEnabled { get; set; }

    #endregion

    #region Dependants

    /// <summary>
    ///     <see cref="Permit"/> dependants from this <see cref="Feature"/>.
    /// </summary>
    [Relation]
    public ICollection<Permit> Permits { get; set; } = [];

    #endregion

    protected override void DesignEntity(EntityTypeBuilder etBuilder) {
        etBuilder.Property(nameof(IsEnabled)).IsRequired();
    }
}
