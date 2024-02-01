namespace Project.Api.Configurations.Swagger
{
    public static class SwaggerConfiguration
    {
        public static void ConfigureSwagger(IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerGen();
        }
    }
}
