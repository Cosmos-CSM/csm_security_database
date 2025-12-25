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
    ///     Drafts an <see cref="CSM_Security_Database_Core.Entities.User"/> data.
    /// </summary>
    /// <param name="ref">
    ///     Default entity data.
    /// </param>
    /// <returns>
    ///     A drafted <see cref="CSM_Security_Database_Core.Entities.User"/>.
    /// </returns>
    static public User User(User? @ref = null) {
        @ref = BaseDraftUtils.Entity(@ref);

        if (string.IsNullOrWhiteSpace(@ref.Username)) {
            @ref.Username = $"{Epy}_usr";
        }

        if (@ref.Password == null || @ref.Password.Empty()) {
            @ref.Password = Encoding.UTF8.GetBytes($"{Epy}_pwd");
        }

        return @ref;
    }

    /// <summary>
    ///     Drafts an <see cref="CSM_Security_Database_Core.Entities.UserInfo"/> data.
    /// </summary>
    /// <param name="ref">
    ///     Default entity data.
    /// </param>
    /// <returns>
    ///     A drafted <see cref="CSM_Security_Database_Core.Entities.UserInfo"/>.
    /// </returns>
    static public UserInfo UserInfo(UserInfo? @ref = null) {
        @ref = BaseDraftUtils.Entity(@ref);

        if (string.IsNullOrWhiteSpace(@ref.Name)) {
            @ref.Name = $"Usr_{Epy}";
        }

        if (string.IsNullOrWhiteSpace(@ref.LastName)) {
            @ref.LastName = $"{Epy}";
        }

        if (string.IsNullOrWhiteSpace(@ref.EMail)) {
            @ref.EMail = $"{Epy}@example.com";
        }

        if (string.IsNullOrWhiteSpace(@ref.Phone)) {
            var random = new Random();
            var phone = random.Next(1000000000, int.MaxValue).ToString()[..10];

            @ref.Phone = phone;
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

    /// <summary>
    ///     Drafts a <see cref="CSM_Security_Database_Core.Entities.Solution"/> data.
    /// </summary>
    /// <param name="ref">
    ///     Default entity data.
    /// </param>
    /// <returns>
    ///     A drafted <see cref="CSM_Security_Database_Core.Entities.Solution"/>.
    /// </returns>
    static public Solution Solution(Solution? @ref = null) {
        @ref = BaseDraftUtils.NamedEntity(@ref);

        if (string.IsNullOrWhiteSpace(@ref.Sign)) {
            @ref.Sign = Epy[..5].ToUpper();
        }


        return @ref;
    }

    /// <summary>
    ///     Drafts a <see cref="CSM_Security_Database_Core.Entities.Feature"/>
    /// </summary>
    /// <param name="ref">
    ///     Default entity data.
    /// </param>
    /// <returns>
    ///     A drafted <see cref="CSM_Security_Database_Core.Entities.Feature"/>.
    /// </returns>
    static public Feature Feature(Feature? @ref = null) {
        @ref = BaseDraftUtils.CatalogEntity(@ref);

        return @ref;
    }

    /// <summary>
    ///     Drafts a <see cref="CSM_Security_Database_Core.Entities.Permit"/> data.
    /// </summary>
    /// <param name="ref">
    ///     Default entity data.
    /// </param>
    /// <returns>
    ///     A drafted <see cref="CSM_Security_Database_Core.Entities.Permit"/>.
    /// </returns>
    static public Permit Permit(Permit? @ref = null) {
        @ref = BaseDraftUtils.CatalogEntity(@ref);

        @ref.Solution = Solution(@ref.Solution);
        @ref.Feature = Feature(@ref.Feature);
        @ref.Action = Action(@ref.Action);

        return @ref;
    }

    /// <summary>
    ///     Drafts a <see cref="CSM_Security_Database_Core.Entities.Profile"/> data.
    /// </summary>
    /// <param name="ref">
    ///     Default entity data.
    /// </param>
    /// <returns>
    ///     A drafted <see cref="CSM_Security_Database_Core.Entities.Profile"/>.
    /// </returns>
    static public Profile Profile(Profile? @ref = null) {
        @ref = BaseDraftUtils.CatalogEntity(@ref);

        return @ref;
    }
}
