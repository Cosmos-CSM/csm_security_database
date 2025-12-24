using CSM_Foundation_Core.Core.Utils;

using Microsoft.EntityFrameworkCore.Design;

namespace CSM_Security_Database_Core;

/// <summary>
///     EF Design time factory for <see cref="SecurityDatabase"/>
/// </summary>
internal class SecurityDatabaseDesignFactory
    : IDesignTimeDbContextFactory<SecurityDatabase> {


    public SecurityDatabase CreateDbContext(string[] args) {
        ConsoleUtils.Warning(
            "Designing database using a design factory",
            new Dictionary<string, object?> {
                { "DesignFactory", GetType().FullName },
                { "Database", typeof(SecurityDatabase).FullName  },
            }
        );

        return new SecurityDatabase();
    }
}
