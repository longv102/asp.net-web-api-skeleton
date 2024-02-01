using Project.Core.Repositories;
using Project.Core.Repositories.Interfaces;

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
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));


            return services;
        }
    }
}
