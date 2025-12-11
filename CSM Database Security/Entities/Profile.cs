
using CSM_Database_Core.Core.Attributes;

using CSM_Security_Database_Core.Abstractions.Bases;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSM_Security_Database_Core.Entities;

/// <summary>
///     Represents a group of permits into th eecosystem for easier security management.
/// </summary>
public class Profile
    : SecurityCatalogEntityBase {

    /// <summary>
    ///     Permits data.
    /// </summary>
    [EntityRelation]
    public ICollection<Permit> Permits { get; set; } = [];

    /// <summary>
    ///     Users data.
    /// </summary>
    [EntityRelation]
    public ICollection<User> Users { get; set; } = [];

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
            .HasMany(nameof(Users))
            .WithMany(nameof(User.Profiles))
            .UsingEntity(
                "Accounts_Profiles",
                con => con.HasOne(typeof(User)).WithMany().HasForeignKey("Account"),
                con => con.HasOne(typeof(Profile)).WithMany().HasForeignKey("Profile")
            );
    }
}
