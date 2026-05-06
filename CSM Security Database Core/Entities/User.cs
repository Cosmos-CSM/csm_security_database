using CSM_Database_Core.Core.Attributes;
using CSM_Database_Core.Core.Extensions;

using CSM_Security_Database_Core.Core;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SecurityEntityBase = CSM_Security_Database_Core.Abstractions.Bases.SecurityEntityBase;

namespace CSM_Security_Database_Core.Entities;

/// <summary>
///     Represents the possible <see cref="User"/> types.
/// </summary>
public enum UserTypes {
    /// <summary>
    ///     User for third-party api integration consumers.
    /// </summary>
    INTEGRATION,

    /// <summary>
    ///     User for a physical person using an visual solution interface.
    /// </summary>
    PERSON,
}

/// <summary>
///     Represents an ecosystem user.
/// </summary>
public class User
    : SecurityEntityBase {

    /// <summary>
    ///     User username.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    ///     User password.
    /// </summary>
    public byte[] Password { get; set; } = null!;

    /// <summary>
    ///     User type.
    /// </summary>
    public UserTypes Type { get; set; } = UserTypes.PERSON;

    /// <summary>
    ///     Whether the user is master.
    /// </summary>
    public bool IsMaster { get; set; } = false;

    /// <summary>
    ///     User information data.
    /// </summary>
    [EntityDependency]
    public UserInfo UserInfo { get; set; } = default!;

    /// <summary>
    ///     Permits data.
    /// </summary>
    [EntityDependency]
    public ICollection<Permit> Permits { get; set; } = [];

    /// <summary>
    ///     Profiles data.
    /// </summary>
    [EntityDependency]
    public ICollection<Profile> Profiles { get; set; } = [];

    /// <inheritdoc/>
    protected override void DesignEntity(EntityTypeBuilder etBuilder) {
        etBuilder.HasIndex(nameof(Username))
            .IsUnique();
        etBuilder.Property(nameof(Username))
            .HasMaxLength(50)
            .IsRequired();

        etBuilder.Property(nameof(Password))
            .IsRequired();

        etBuilder.Link<User, UserInfo>(
                nameof(UserInfo),
                isRequired: true,
                isIndex: true,
                isAutoLoaded: true,
                deleteBehavior: DeleteBehavior.Cascade
            );

        etBuilder
            .HasMany(nameof(Permits))
            .WithMany(nameof(Permit.Users))
            .UsingEntity(
                Constants.Connectors.AccountsPermits.Connector,
                con => con.HasOne(typeof(Permit)).WithMany().HasForeignKey(Constants.Connectors.AccountsPermits.Permit).OnDelete(DeleteBehavior.Cascade),
                con => con.HasOne(typeof(User)).WithMany().HasForeignKey(Constants.Connectors.AccountsPermits.Account).OnDelete(DeleteBehavior.Cascade)
            );

        etBuilder
            .HasMany(nameof(Profiles))
            .WithMany(nameof(Profile.Users))
            .UsingEntity(
                Constants.Connectors.AccountsProfiles.Connector,
                con => con.HasOne(typeof(Profile)).WithMany().HasForeignKey(Constants.Connectors.AccountsProfiles.Profile).OnDelete(DeleteBehavior.Cascade),
                con => con.HasOne(typeof(User)).WithMany().HasForeignKey(Constants.Connectors.AccountsPermits.Account).OnDelete(DeleteBehavior.Cascade)
            );
    }
}
