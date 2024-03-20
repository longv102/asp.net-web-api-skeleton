
namespace Project.Api.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        public GlobalExceptionHandlingMiddleware()
        {
            
        }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
