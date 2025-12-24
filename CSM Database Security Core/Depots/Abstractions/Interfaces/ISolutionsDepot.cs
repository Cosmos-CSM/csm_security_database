using CSM_Database_Core.Depots.Abstractions.Interfaces;

using CSM_Security_Database_Core.Entities;

namespace CSM_Security_Database_Core.Depots.Abstractions.Interfaces;

/// <summary>
///     Represents an entities depot provider for <see cref="Solution"/>.
/// </summary>
public interface ISolutionsDepot 
    : IDepot<Solution> {
}
