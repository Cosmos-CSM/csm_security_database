using CSM_Database_Core.Core.Attributes;
using CSM_Database_Core.Core.Extensions;
using CSM_Database_Core.Entities.Abstractions.Interfaces;

using CSM_Security_Database_Core.Core;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SecurityEntityBase = CSM_Security_Database_Core.Abstractions.Bases.SecurityEntityBase;

namespace CSM_Security_Database_Core.Entities;

/// <summary>
///     Represents the possible <see cref="IUser"/> types.
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
public interface IUser
    : IEntity {

    #region Properties

    /// <summary>
    ///     User username.
    /// </summary>
    string Username { get; set; }

    /// <summary>
    ///     User password.
    /// </summary>
    byte[] Password { get; set; }

    /// <summary>
    ///     User type.
    /// </summary>
    UserTypes Type { get; set; }

    /// <summary>
    ///     Whether has total ecosystem access.
    /// </summary>
    bool IsMaster { get; set; }

    #endregion

    #region Relations

    [EntityRelation]
    IUserInfo UserInfo { get; set; }

    /// <summary>
    ///     <see cref="Permit"/> related to this <see cref="User"/>
    /// </summary>
    [EntityRelation]
    ICollection<Permit> Permits { get; set; }

    /// <summary>
    ///     <see cref="Profile"/> related to this <see cref="User"/>
    /// </summary>
    [EntityRelation]
    ICollection<Profile> Profiles { get; set; }

    #endregion
}

public class User
    : SecurityEntityBase, IUser {

    #region Properties

    public string Username { get; set; } = string.Empty;

    public byte[] Password { get; set; } = null!;

    public UserTypes Type { get; set; } = UserTypes.PERSON;

    public bool IsMaster { get; set; } = false;

    #endregion

    #region Relations

    [EntityRelation]
    public IUserInfo UserInfo { get; set; } = default!;

    /// <summary>
    ///     <see cref="Permit"/> related to this <see cref="User"/>
    /// </summary>
    [EntityRelation]
    public ICollection<Permit> Permits { get; set; } = [];

    /// <summary>
    ///     <see cref="Profile"/> related to this <see cref="User"/>
    /// </summary>
    [EntityRelation]
    public ICollection<Profile> Profiles { get; set; } = [];

    #endregion

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
                Required: true,
                Index: true,
                Auto: true,
                Deletion: DeleteBehavior.Cascade
            );

        etBuilder
            .HasMany(nameof(Permits))
            .WithMany(nameof(Permit.Accounts))
            .UsingEntity(
                Constants.Connectors.AccountsPermits.Connector,
                con => con.HasOne(typeof(Permit)).WithMany().HasForeignKey(Constants.Connectors.AccountsPermits.Permit).OnDelete(DeleteBehavior.Cascade),
                con => con.HasOne(typeof(User)).WithMany().HasForeignKey(Constants.Connectors.AccountsPermits.Account).OnDelete(DeleteBehavior.Cascade)
            );

        etBuilder
            .HasMany(nameof(Profiles))
            .WithMany(nameof(Profile.Accounts))
            .UsingEntity(
                Constants.Connectors.AccountsProfiles.Connector,
                con => con.HasOne(typeof(Profile)).WithMany().HasForeignKey(Constants.Connectors.AccountsProfiles.Profile).OnDelete(DeleteBehavior.Cascade),
                con => con.HasOne(typeof(User)).WithMany().HasForeignKey(Constants.Connectors.AccountsPermits.Account).OnDelete(DeleteBehavior.Cascade)
            );
    }
}
