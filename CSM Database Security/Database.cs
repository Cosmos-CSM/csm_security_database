using CSM_Foundation.Database;

using CSM_Foundation_Database.Models;

using Microsoft.EntityFrameworkCore;

namespace CSM_Database_Security;

/// <summary>
///     Represents a [CSM Security] database context.
/// </summary>
public interface IDatabase
    : CSM_Foundation.Database.IDatabase {
}

/// <inheritdoc cref="IDatabase"/>
public class Database
    : BDatabase<Database>, IDatabase {

    /// <summary>
    ///     Database signature
    /// </summary>
    public const string SIGN = "CSMS";

    #region DbSets

    #endregion

    /// <summary>
    ///     Creates a new <see cref="Database"/> instance.
    /// </summary>
    /// <param name="Connection">
    ///     Connection parameters information.
    /// </param>
    public Database(ConnectionOptions Connection)
        : base(SIGN, Connection) {
    }

    /// <summary>
    ///     Creates a new <see cref="Database"/> instance.
    /// </summary>
    /// <param name="Connection">
    ///     Connection parameters information.
    /// </param>
    /// <param name="Options">
    ///     Custom EF Native options.
    /// </param>
    public Database(ConnectionOptions Connection, DbContextOptions<Database> Options)
        : base(SIGN, Connection, Options) {
    }
}