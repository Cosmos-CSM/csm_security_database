using System.Text.Json.Serialization;

using CSM_Database_Core.Entities.Abstractions.Bases;

namespace CSM_Security_Database_Core.Abstractions.Bases;

/// <summary>
///     Represents a [CSM Database Security] entity base as status identificator.
/// </summary>
public abstract class SecurityStateEntityBase
    : NamedEntityBase {

    /// <inheritdoc/>
    [JsonIgnore]
    public override Type Database { get; init; } = typeof(SecurityDatabase);

}
