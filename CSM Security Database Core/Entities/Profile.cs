using CSM_Database_Core.Core.Attributes;

using CSM_Security_Database_Core.Abstractions.Bases;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Constants = CSM_Security_Database_Core.Core.Constants;

namespace CSM_Security_Database_Core.Entities;

/// <summary>
///     Represents a group of permits into th eecosystem for easier security management.
/// </summary>
public class Profile
    : SecurityNamedEntityBase {

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

    /// <inheritdoc/>
    protected override void DesignEntity(EntityTypeBuilder etBuilder) {
        base.DesignEntity(etBuilder);

        etBuilder
            .HasMany(nameof(Permits))
            .WithMany(nameof(Permit.Profiles))
            .UsingEntity(
                Constants.Connectors.PermitsProfiles.Connector,
                con => con.HasOne(typeof(Permit)).WithMany().HasForeignKey(Constants.Connectors.PermitsProfiles.Permit),
                con => con.HasOne(typeof(Profile)).WithMany().HasForeignKey(Constants.Connectors.PermitsProfiles.Profile)
            );

        etBuilder
            .HasMany(nameof(Users))
            .WithMany(nameof(User.Profiles))
            .UsingEntity(
                Constants.Connectors.UsersProfiles.Connector,
                con => con.HasOne(typeof(User)).WithMany().HasForeignKey(Constants.Connectors.UsersProfiles.User),
                con => con.HasOne(typeof(Profile)).WithMany().HasForeignKey(Constants.Connectors.UsersProfiles.Profile)
            );
    }
}
