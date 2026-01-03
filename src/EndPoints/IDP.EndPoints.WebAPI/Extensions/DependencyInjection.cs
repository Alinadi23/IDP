using IDP.Core.ApplicationService.Users.Interfaces;
using IDP.Core.Domain.Users.Interfaces;
using IDP.Infra.Persistence.Sql.Users.Repositories;

namespace IDP.EndPoints.WebAPI.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesFromAssembly(this IServiceCollection services)
        {

            var assembly = typeof(IUserService).Assembly;

            services.Scan(scan => scan
                .FromAssemblies(assembly)
                .AddClasses(c => c.Where(t =>
                    t.IsClass &&
                    !t.IsAbstract &&
                    t.GetInterfaces().Any(i => i == typeof(IUserService))
                ))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }

        public static IServiceCollection AddRepositoriesFromAssembly(this IServiceCollection services)
        {
            var assembly = typeof(UserRepository).Assembly;

            services.Scan(scan => scan
                .FromAssemblies(assembly)
                .AddClasses(c => c.Where(t =>
                    t.IsClass &&
                    !t.IsAbstract &&
                    t.GetInterfaces().Any(i => i == typeof(IUserRepository))
                ))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
