using CSM_Database_Core.Core.Attributes;

using CSM_Security_Database_Core.Abstractions.Bases;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSM_Security_Database_Core.Entities;

/// <summary>
///     Types of vendors available in the system.
/// </summary>
public enum VendorType {
    /// <summary>
    /// 
    /// </summary>
    Owner,
    /// <summary>
    /// 
    /// </summary>
    Supplier,
    /// <summary>
    /// 
    /// </summary>
    Contractor,
    /// <summary>
    /// 
    /// </summary>
    Subcontractor,
    /// <summary>
    /// 
    /// </summary>
    ServiceProvider,
    /// <summary>
    /// 
    /// </summary>
    Consultant,
    /// <summary>
    /// 
    /// </summary>
    Partner,
    /// <summary>
    /// 
    /// </summary>
    Subtenant,
}

/// <summary>
/// Represents a vendor entity in the security database, which can be an owner, supplier, contractor, etc. Each vendor can have multiple users associated with it.
/// </summary>
public class Vendor : SecurityCatalogEntityBase {

    #region Properties
    /// <summary>
    ///     <see cref="Vendor"/> type.
    /// </summary>
    public VendorType Type { get; set; }

    #endregion

    #region Dependants

    /// <summary>
    ///    Collection of <see cref="User"/> linked to this <see cref="Vendor"/>.
    /// </summary> 
    [EntityRelation]
    public ICollection<User> Users { get; set; } = [];

    #endregion

    /// <inheritdoc/>
    protected override void DesignEntity(EntityTypeBuilder etBuilder) {
        etBuilder.Property(nameof(Type)).IsRequired();
    }

}


