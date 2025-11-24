using System.Text.Json.Serialization;

namespace CSM_Database_Security.Bases;

/// <summary>
///     Represents a [CSM Database Security] entity base with naming identification.
/// </summary>
/// <remarks>
///     Usage must be exclusively for [CSM Database Security] entities.
/// </remarks>
public abstract class BNamedEntity
    : CSM_Foundation_Database.Entities.Bases.BNamedEntity {

    [JsonIgnore]
    public override Type Database { get; init; } = typeof(Database);
}
