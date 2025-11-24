using CSM_Foundation.Database;

using CSM_Foundation_Database.Entities;
using CSM_Foundation_Database.Extensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using BEntity = CSM_Database_Security.Bases.BEntity;

namespace CSM_Database_Security.Entities.Users;

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


/// <summary>
///     Represents a [CSM] security solution base auth user, representing credentials to authenticate users along
///     ecosystem solutions.
/// </summary>
[ActivatorReference(typeof(User))]
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

    [Relation]
    IUserInfo UserInfo { get; set; }

    /// <summary>
    ///     <see cref="Permit"/> related to this <see cref="User"/>
    /// </summary>
    [Relation]
    ICollection<Permit> Permits { get; set; }

    /// <summary>
    ///     <see cref="Profile"/> related to this <see cref="User"/>
    /// </summary>
    [Relation]
    ICollection<Profile> Profiles { get; set; }

    #endregion
}

public class User
    : BEntity, IUser {

    #region Properties

    public string Username { get; set; } = string.Empty;

    public byte[] Password { get; set; } = null!;

    public UserTypes Type { get; set; } = UserTypes.PERSON;

    public bool IsMaster { get; set; } = false;

    #endregion

    #region Relations

    [Relation]
    public IUserInfo UserInfo { get; set; } = default!;

    /// <summary>
    ///     <see cref="Permit"/> related to this <see cref="Users.User"/>
    /// </summary>
    [Relation]
    public ICollection<Permit> Permits { get; set; } = [];

    /// <summary>
    ///     <see cref="Profile"/> related to this <see cref="Users.User"/>
    /// </summary>
    [Relation]
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
