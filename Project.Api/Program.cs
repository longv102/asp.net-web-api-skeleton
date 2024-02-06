using Project.Api.Middlewares;

namespace Project.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Extensions.ServiceCollectionExtensions.Register(builder.Services);
            Configurations.Swagger.SwaggerConfiguration.ConfigureSwagger(builder.Services);
            Configurations.Jwt.JwtConfiguration.ConfigureJwt(builder.Services, builder.Configuration);
            Configurations.Database.SqlServerConfiguration.ConfigureSqlServer(builder.Services, builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<GlobalExceptionMiddleware>();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
