using System.Text;

using CSM_Database_Testing;

using CSM_Foundation_Core.Core.Extensions;
using CSM_Foundation_Core.Core.Utils;

using CSM_Security_Database_Core.Entities;

using Action = CSM_Security_Database_Core.Entities.Action;

namespace CSM_Security_Database_Testing.Utils;


/// <summary>
///     Handles [CSM Security Database] objects drafting for testing purposes.
/// </summary>
static public class DraftUtils {

    /// <summary>
    ///     Gets a new random 16 length string.
    /// </summary>
    static string Epy => RandomUtils.String(16);

    /// <summary>
    ///     Drafts an <see cref="User"/> data.
    /// </summary>
    /// <param name="ref">
    ///     Default entity data.
    /// </param>
    /// <returns>
    ///     A drafted <see cref="User"/>.
    /// </returns>
    static public User Account(User? @ref = null) {
        @ref ??= BaseDraftUtils.Entity(@ref);

        if (string.IsNullOrWhiteSpace(@ref.Username)) {
            @ref.Username = $"{Epy}_usr";
        }

        if (@ref.Password.Empty()) {
            @ref.Password = Encoding.UTF8.GetBytes($"{Epy}_pwd");
        }

        return @ref;
    }

    /// <summary>
    ///     Drafts an <see cref="CSM_Security_Database_Core.Entities.Action"/> data.
    /// </summary>
    /// <param name="ref">
    ///     Default entity data.
    /// </param>
    /// <returns>
    ///     A drafted <see cref="CSM_Security_Database_Core.Entities.Action"/>.
    /// </returns>
    static public Action Action(Action? @ref = null) {
        return BaseDraftUtils.CatalogEntity(@ref);
    }
}
