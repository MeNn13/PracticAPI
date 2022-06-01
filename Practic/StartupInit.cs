using Microsoft.Extensions.DependencyInjection;
using Practic.Data.Interfaces;
using Practic.Data.Repository;
using Practic.Service.Implementations;
using Practic.Service.Interfaces;

namespace Practic
{
    public static class StartupInit
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClassService, ClassService>();
        }
    }
}
