using CSM_Security_Database_Core.Abstractions.Bases;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSM_Security_Database_Core.Entities;

/// <summary>
///     Represents the <see cref="Entities.User"/> additional information.
/// </summary>
public class UserInfo
    : SecurityEntityBase {

    /// <summary>
    ///     User personal name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     User personal last name.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    ///     User personal email.
    /// </summary>
    public string EMail { get; set; } = string.Empty;

    /// <summary>
    ///     User personal phone number.
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    protected override void DesignEntity(EntityTypeBuilder etBuilder) {
        etBuilder.Property(nameof(Name))
            .HasMaxLength(100)
            .IsRequired();

        etBuilder.Property(nameof(LastName))
            .HasMaxLength(100)
            .IsRequired();

        etBuilder.HasIndex(nameof(EMail))
            .IsUnique();

        etBuilder.Property(nameof(EMail))
            .HasMaxLength(100)
            .IsRequired();

        etBuilder.HasIndex(nameof(Phone))
            .IsUnique();
        etBuilder.Property(nameof(Phone))
            .HasMaxLength(14)
            .IsRequired();
    }
}
