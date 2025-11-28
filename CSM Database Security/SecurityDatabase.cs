using CSM_Database_Core;
using CSM_Database_Core.Abstractions.Interfaces;
using CSM_Database_Core.Core.Models;

namespace CSM_Security_Database_Core;

/// <summary>
///     Represents a [CSM Security] database context.
/// </summary>
public class SecurityDatabase
    : DatabaseBase<SecurityDatabase>, IDatabase {

    /// <summary>
    ///     Database signature
    /// </summary>
    public override string Sign { get; } = "CSMS";

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    public SecurityDatabase()
        : base() {
    }

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    /// <param name="databaseOptions">
    ///     Database context options.
    /// </param>
    public SecurityDatabase(DatabaseOptions<SecurityDatabase> databaseOptions)
        : base(databaseOptions) {
    }
}