using System.Text;

using CSM_Foundation_Core.Core.Extensions;
using CSM_Foundation_Core.Core.Utils;

using CSM_Security_Database_Core.Entities;

namespace CSM_Security_Database_Testing.Utils;


/// <summary>
///     Handles [CSM Security Database] objects drafting for testing purposes.
/// </summary>
public static class DraftUtils {

    /// <summary>
    ///     Gets a new random 16 length string.
    /// </summary>
    static string Epy => RandomUtils.String(16);

    /// <summary>
    ///     Drafts an <see cref="Entities.Accounts.Account"/> entity.
    /// </summary>
    /// <param name="ref">
    ///     Reference data to keep.
    /// </param>
    /// <returns>
    ///     A drafted instance.
    /// </returns>
    static public User Account(User? @ref = null) {
        @ref ??= new User();

        @ref.Id = 0;
        @ref.Permits ??= [];
        @ref.Profiles ??= [];

        if (string.IsNullOrWhiteSpace(@ref.Username)) {
            @ref.Username = $"{Epy}_usr";
        }

        if (@ref.Password.Empty()) {
            @ref.Password = Encoding.UTF8.GetBytes($"{Epy}_pwd");
        }

        return @ref;
    }
}
