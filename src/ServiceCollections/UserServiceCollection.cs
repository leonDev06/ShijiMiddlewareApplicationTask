using ShijiMiddlewareTask.User.Providers;
using ShijiMiddlewareTask.User.Services;

namespace ShijiMiddlewareTask.ServiceCollections
{
    public static class UserServiceCollection
    {
        // Although we only have 2 service/repository for now, I'm ensuring code-scalibility by grouping our services.
        // This will prove to be useful once we already have tens or hundreds of services depending on how big the app is
        public static IServiceCollection AddUserServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserProvider, UserProvider>();

            return services;
        }
    }
}
