using Project.Core.Repositories;
using Project.Domain.Repositories;

namespace Project.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Register repositories here
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            // Register services here
            

            return services;
        }
    }
}
