using Project.Api.Configurations;
using Project.Api.Extensions;
using Project.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Register();
SwaggerConfiguration.ConfigureSwagger(builder.Services, builder.Configuration);
SqlServerConfiguration.ConfigureSqlServer(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
