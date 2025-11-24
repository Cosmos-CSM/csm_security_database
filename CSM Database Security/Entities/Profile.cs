using CSM_Database_Security.Bases;
using CSM_Database_Security.Entities.Users;

using CSM_Foundation_Database.Entities;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSM_Database_Security.Entities;

/// <summary>
///     [Entity] that stores a relation between a collection of <see cref="Permit"/> with an <see cref="User"/>
/// </summary>
public class Profile
    : BNamedEntity {

    #region Relations

    /// <summary>
    ///     <see cref="Permit"/> related to this <see cref="Profile"/>.
    /// </summary>
    [Relation]
    public ICollection<Permit> Permits { get; set; } = default!;

    /// <summary>
    ///     <see cref="User"/> related to this <see cref="Profile"/>.
    /// </summary>
    [Relation]
    public ICollection<User> Accounts { get; set; } = default!;

    #endregion

    protected override void DesignEntity(EntityTypeBuilder etBuilder) {

        etBuilder
            .HasMany(nameof(Permits))
            .WithMany(nameof(Permit.Profiles))
            .UsingEntity(
                "Profiles_Permits",
                con => con.HasOne(typeof(Permit)).WithMany().HasForeignKey("Permit"),
                con => con.HasOne(typeof(Profile)).WithMany().HasForeignKey("Profile")
            );

        etBuilder
            .HasMany(nameof(Accounts))
            .WithMany(nameof(User.Profiles))
            .UsingEntity(
                "Accounts_Profiles",
                con => con.HasOne(typeof(User)).WithMany().HasForeignKey("Account"),
                con => con.HasOne(typeof(Profile)).WithMany().HasForeignKey("Profile")
            );
    }
}
