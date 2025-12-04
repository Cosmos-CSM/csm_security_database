using System.ComponentModel.DataAnnotations;

using CSM_Database_Core.Core.Attributes;
using CSM_Database_Core.Core.Extensions;

using CSM_Security_Database_Core.Abstractions.Bases;
using CSM_Security_Database_Core.Entities.Solutions;
using CSM_Security_Database_Core.Entities.Users;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSM_Security_Database_Core.Entities;

/// <summary>
///     [Entity] that stores and handles specific Feature / Solution / Action authorization for Accounts.
/// </summary>
public class Permit
    : SecurityNamedEntityBase {

    #region Properties

    /// <summary>
    ///     Unique identifier reference.
    /// </summary>
    /// <remarks>
    ///     Strictly 8 length value
    /// </remarks>
    [StringLength(8, MinimumLength = 8)]
    public string Reference { get; set; } = string.Empty;

    /// <summary>
    ///     Wheter the Permit is globally enabled.
    /// </summary>
    public bool Enabled { get; set; }

    #endregion

    #region Relations

    /// <summary>
    ///     Solution information.
    /// </summary>
    /// <remarks>
    ///     Auto included relation.
    /// </remarks>
    [EntityRelation]
    public Solution Solution { get; set; } = default!;

    /// <summary>
    ///     Feature information.
    /// </summary>
    /// <remarks>
    ///     Auto included relation.
    /// </remarks>
    [EntityRelation]
    public Feature Feature { get; set; } = default!;

    /// <summary>
    ///     Action information.
    /// </summary>
    /// <remarks>
    ///     Auto included relation.
    /// </remarks>
    [EntityRelation]
    public Action Action { get; set; } = default!;

    #endregion

    #region Dependants

    /// <summary>
    ///     <see cref="Profile"/> dependants from this <see cref="Permit"/>.
    /// </summary>
    [EntityRelation]
    public ICollection<Profile> Profiles { get; set; } = [];

    /// <summary>
    ///     <see cref="User"/> dependants from this <see cref="Permit"/>.
    /// </summary>
    [EntityRelation]
    public ICollection<User> Accounts { get; set; } = [];

    #endregion

    protected override void DesignEntity(EntityTypeBuilder etBuilder) {
        etBuilder.HasIndex(nameof(Reference)).IsUnique();
        etBuilder.Property(nameof(Reference)).HasMaxLength(8).IsFixedLength().IsRequired();

        etBuilder.Property(nameof(Enabled)).IsRequired();

        etBuilder.Link<Permit, Solution>(
                nameof(Solution),
                Required: true,
                Auto: true
            );
        etBuilder.Link<Permit, Feature>(
                nameof(Feature),
                Required: true,
                Auto: true
            );
        etBuilder.Link<Permit, Action>(
                nameof(Action),
                Required: true,
                Auto: true
            );
        etBuilder.HasIndex("ActionShadow", "SolutionShadow", "FeatureShadow");
    }

    /// <summary>
    ///     Stores a static catalog of <see cref="Permit"/> references.
    /// </summary>
    public enum References {
        /// <summary>
        ///     <para> Solution: TWSMF </para>
        ///     <para> Feature: Development </para>
        ///     <para> Action: Qualify </para>
        /// </summary>
        TWSMFD01,
    }
}