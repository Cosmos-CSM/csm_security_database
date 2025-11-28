using CSM_Database_Testing.Abstractions.Bases;

using CSM_Security_Database_Core;

namespace Integration_Tests;

/// <summary>
///     Integration tests class for <see cref="CSM_Security_Database_Core.SecurityDatabase"/>
/// </summary>
public class SecurityDatabaseTests
    : TestingDatabaseBase<SecurityDatabase> {


    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    public SecurityDatabaseTests()
        : base() {
    }
}
