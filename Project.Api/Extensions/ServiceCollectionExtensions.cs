using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Project.Api.Middlewares;
using Project.Core.Applications;
using Project.Core.Applications.Interfaces;
using Project.Core.Repositories;
using Project.Domain.Repositories;
using Project.Persistence.Databases;

namespace Project.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            // Database: Sqlserver
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging();
            });

            // Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Project API v1",
                    Version = "1",
                    Description = ""
                });

                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "Project API v2",
                    Version = "2",
                    Description = ""
                });
            });

            // API versioning configuration
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                // Reports the supported API versions in the api-supported-versions response header
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                // Configure how to read the API version specified by the client
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("X-Api-Version")
                );
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });

            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<GlobalExceptionHandlingMiddleware>();
            // Register repositories here
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            // Register services here
            services.AddScoped<ISampleService, SampleService>();

            services.AddHttpContextAccessor();
            return services;
        }
    }
}
