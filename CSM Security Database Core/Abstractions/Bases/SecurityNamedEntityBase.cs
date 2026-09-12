using System.Text.Json.Serialization;

using CSM_System_Database_Core.Abstractions.Bases;

namespace CSM_Security_Database_Core.Abstractions.Bases;

/// <summary>
///     Represents a [CSM Database Security] entity base with naming identification.
/// </summary>
/// <remarks>
///     Usage must be exclusively for [CSM Database Security] entities.
/// </remarks>
public abstract class SecurityNamedEntityBase
    : StateSystemNamedEntityBase {

    /// <inheritdoc/>
    [JsonIgnore]
    public override Type Database { get; init; } = typeof(SecurityDatabase);

}
