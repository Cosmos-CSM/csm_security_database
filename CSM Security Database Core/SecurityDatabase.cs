using CSM_Database_Core;
using CSM_Database_Core.Abstractions.Interfaces;
using CSM_Database_Core.Core.Models;

using CSM_Security_Database_Core.Entities;

using Microsoft.EntityFrameworkCore;

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

    /// <summary>
    ///     Users DB Set.
    /// </summary>
    public DbSet<User> Users { get; set; } = default!;

    /// <summary>
    ///     Permits DB Set.
    /// </summary>
    public DbSet<Permit> Permits { get; set; } = default!;

    /// <summary>
    ///     Profiles DB Set.
    /// </summary>
    public DbSet<Profile> Profiles { get; set; } = default!;

    /// <summary>
    ///     Features DB Set.
    /// </summary>
    public DbSet<Feature> Features { get; set; } = default!;

    /// <summary>
    ///     Solutions DB Set.
    /// </summary>
    public DbSet<Solution> Solutions { get; set; } = default!;

    /// <summary>
    ///     Actions DB Set.
    /// </summary>
    public DbSet<Entities.Action> Actions { get; set; } = default!;
}