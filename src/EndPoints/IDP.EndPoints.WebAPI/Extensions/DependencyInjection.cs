using IDP.Core.ApplicationService.Users.Interfaces;
using IDP.Core.Domain.Common;
using IDP.Core.Domain.Users.Interfaces;
using IDP.Infra.Persistence.Sql.Common;
using IDP.Infra.Persistence.Sql.Users.Repositories;

namespace IDP.EndPoints.WebAPI.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesFromAssembly(this IServiceCollection services)
        {

            var assembly = typeof(IApplicationService).Assembly;

            services.Scan(scan => scan
                .FromAssemblies(assembly)
                .AddClasses(c => c.Where(t =>
                    t.IsClass &&
                    !t.IsAbstract &&
                    t.GetInterfaces().Any(i => i == typeof(IApplicationService))
                ))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }

        public static IServiceCollection AddRepositoriesFromAssembly(this IServiceCollection services)
        {
            var assembly = typeof(BaseRepository<,>).Assembly;

            services.Scan(scan => scan
                .FromAssemblies(assembly)
                .AddClasses(c => c.Where(t =>
                    t.IsClass &&
                    !t.IsAbstract &&
                    t.GetInterfaces().Any(i => i == typeof(IBaseRepository<>))
                ))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
