using CSM_Foundation_Database_Testing;

namespace CSM_Database_Security.IT;

/// <summary>
///     Represents database context tests for <see cref="Database"/>.
/// </summary>
public class ITDatabase
    : BQ_Database<Database> {

    public ITDatabase()
        : base(Database.SIGN) {
    }
}
