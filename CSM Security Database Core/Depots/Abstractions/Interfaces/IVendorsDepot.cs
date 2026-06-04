using CSM_Database_Core.Depots.Abstractions.Interfaces;

using CSM_Security_Database_Core.Entities;

namespace CSM_Security_Database_Core.Depots.Abstractions.Interfaces;

/// <summary>
///     representing a depot to handle <see cref="Vendor"/> dataDatabases entity mirror.
/// </summary>
public interface IVendorsDepot
    : IDepot<Vendor> {
}