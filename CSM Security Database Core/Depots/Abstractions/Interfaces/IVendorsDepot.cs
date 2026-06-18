using CSM_Database_Core.Depots.Abstractions.Interfaces;

using CSM_Security_Database_Core.Entities;

namespace CSM_Security_Database_Core.Depots.Abstractions.Interfaces;

/// <summary>
///     Represents a depot for handling <see cref="Vendor"/> entities.
/// </summary>
public interface IVendorsDepot
    : IDepot<Vendor> {
}