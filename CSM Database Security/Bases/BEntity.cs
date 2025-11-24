using System.Text.Json.Serialization;

namespace CSM_Database_Security.Bases;

/// <summary>
///     Represents a [CSM Database Security] entity base. 
/// </summary>
/// <remarks>
///     Usage must be exclusively for [CSM Database Security] entities.
/// </remarks>
public abstract class BEntity
    : CSM_Foundation.Database.BEntity {

    [JsonIgnore]
    public override Type Database { get; init; } = typeof(Database);
}

