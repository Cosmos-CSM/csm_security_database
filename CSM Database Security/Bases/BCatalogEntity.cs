
namespace CSM_Database_Security.Bases;

/// <summary>
///     Represents a [CSM Security] database template base catalog entity.
/// </summary>
public class BCatalogEntity
    : CSM_Foundation_Database.Entities.Bases.BCatalogEntity {
    public override Type Database { get; init; } = typeof(Database);
}
