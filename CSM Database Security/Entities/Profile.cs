
using CSM_Security_Database_Core.Abstractions.Bases;
using CSM_Security_Database_Core.Entities.Abstractions.Interfaces;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSM_Security_Database_Core.Entities;

/// <summary>
///     [Entity] that stores a relation between a collection of <see cref="Permit"/> with an <see cref="User"/>
/// </summary>
public class Profile
    : SecurityCatalogEntityBase, IProfile {
    public ICollection<Permit> Permits { get; set; }
    public ICollection<User> Accounts { get; set; }

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
