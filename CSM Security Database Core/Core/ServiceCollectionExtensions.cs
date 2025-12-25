using CSM_Database_Core.Core.Models;

using CSM_Security_Database_Core.Depots;
using CSM_Security_Database_Core.Depots.Abstractions.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CSM_Security_Database_Core.Core;

public static class ServiceCollectionExtensions {

    /// <summary>
    ///     Registers into the services collection the <see cref="SecurityDatabase"/> context and depots service.
    /// </summary>
    /// <param name="services">
    ///     Extended instance.
    /// </param>
    /// <param name="databaseOptions">
    ///     Database options.
    /// </param>
    /// <returns>
    ///     An updated service collection.
    /// </returns>
    public static IServiceCollection AddSecurityDatabaseServices(this IServiceCollection services, DatabaseOptions<SecurityDatabase>? databaseOptions = null) {

        // Register DbContext
        services.AddScoped(
                provider =>
                databaseOptions != null
                    ? new SecurityDatabase(databaseOptions)
                    : new SecurityDatabase()
            );

        // Registering depots
        services.AddScoped<IUsersDepot, UsersDepot>();
        services.AddScoped<IActionsDepot, ActionsDepot>();
        services.AddScoped<IPermitsDepot, PermitsDepot>();
        services.AddScoped<IProfilesDepot, ProfilesDepot>();
        services.AddScoped<IFeaturesDepot, FeaturesDepot>();
        services.AddScoped<ISolutionsDepot, SolutionsDepot>();
        services.AddScoped<IUserInfosDepot, UserInfosDepot>();

        return services;
    }

}
