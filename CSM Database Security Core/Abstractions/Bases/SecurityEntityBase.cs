using System.Text.Json.Serialization;

using CSM_Database_Core;

namespace CSM_Security_Database_Core.Abstractions.Bases;

/// <summary>
///     Represents a [CSM Database Security] entity base. 
/// </summary>
/// <remarks>
///     Usage must be exclusively for [CSM Database Security] entities.
/// </remarks>
public abstract class SecurityEntityBase
    : EntityBase {

    [JsonIgnore]
    public override Type Database { get; init; } = typeof(SecurityDatabase);
}

