using BLL.Handlers;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Repsitory_Coding_Prac.ServiceRegistry
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectHandler, ProjectHandler>();
            return services;
        }
    }
}
