using System.Text.Json.Serialization;

using CSM_Database_Core;
using CSM_Database_Core.Core.Attributes;
using CSM_Database_Core.Core.Extensions;

using CSM_Security_Database_Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using EntityState = CSM_Security_Database_Core.Entities.EntityState;


namespace CSM_Security_Database_Core.Abstractions.Bases;

/// <summary>
///     Represents a [CSM Database Security] entity base. 
/// </summary>
/// <remarks>
///     Usage must be exclusively for [CSM Database Security] entities.
/// </remarks>
public abstract class SecurityEntityBase
    : EntityBase {

    /// <inheritdoc/>
    [JsonIgnore]
    public override Type Database { get; init; } = typeof(SecurityDatabase);

    /// <inheritdoc/>
    [EntityRelation]
    public EntityState State { get; set; } = default!;

    /// <inheritdoc/>
    protected override void DesignEntity(EntityTypeBuilder etBuilder) {
        base.DesignEntity(etBuilder);

        const string shadowProperty = $"{nameof(State)}Shadow";

        etBuilder
            .Property<long>(shadowProperty)
            .HasColumnName(nameof(State))
            .HasColumnType("bigint")
            .IsRequired();

        etBuilder
            .HasOne(typeof(EntityState), nameof(State))
            .WithMany()
            .HasForeignKey(shadowProperty)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        etBuilder
            .Navigation(nameof(State))
            .AutoInclude();
    }


}

