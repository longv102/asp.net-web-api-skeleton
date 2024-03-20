using Microsoft.EntityFrameworkCore;
using Project.Persistence.Databases;

namespace Project.Api.Configurations
{
    public static class SqlServerConfiguration
    {
        public static IServiceCollection ConfigureSqlServer(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")); throw new InvalidOperationException("Cannot connect to the database!");
            });

            return services;
        }
    }
}
