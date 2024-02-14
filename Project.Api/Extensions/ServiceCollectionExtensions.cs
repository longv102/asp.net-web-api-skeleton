using Project.Core.Applications.Repositories;
using Project.Core.Applications.Repositories.Interfaces;

namespace Project.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Register repositories and services here
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            return services;
        }


    }
}
