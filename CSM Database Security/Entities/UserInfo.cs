using System.ComponentModel.DataAnnotations;

using CSM_Security_Database_Core.Abstractions.Bases;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSM_Security_Database_Core.Entities;

public interface IUserInfo {

    #region Properties

    /// <summary>
    ///     User first name.
    /// </summary>
    [StringLength(100, MinimumLength = 1)]
    string Name { get; set; }

    /// <summary>
    ///     User last name.
    /// </summary>
    [StringLength(100, MinimumLength = 1)]
    string LastName { get; set; }

    /// <summary>
    ///     Electronic mail address for sending and communication purposes.
    /// </summary>
    [StringLength(100, MinimumLength = 1)]
    string EMail { get; set; }

    /// <summary>
    ///     Phone number for communication purposes.
    /// </summary>
    /// <remarks>
    ///     This proeprty have length restriction: ( >= 10 & <= 14)
    /// </remarks>
    [StringLength(14, MinimumLength = 10)]
    string Phone { get; set; }

    #endregion

    #region Relations

    /// <summary>
    ///     User data.
    /// </summary>
    public IUser? User { get; set; }

    #endregion
}

/// <summary>
///     Represents the <see cref="Entities.User"/> identification information.
/// </summary>
public class UserInfo
    : SecurityEntityBase, IUserInfo {

    #region Properties

    public string Name { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string EMail { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    #endregion

    #region Relations
    public IUser? User { get; set; }

    #endregion

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
