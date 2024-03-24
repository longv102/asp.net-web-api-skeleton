
using Project.Domain.Errors;
using Project.Domain.Exceptions;
using System.Net;

namespace Project.Api.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            } 
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // Default status code for unhandled exception
            var statusCode = HttpStatusCode.InternalServerError;

            switch (ex)
            {
                case KeyNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                // Retrieved a list but it is empty
                case InvalidOperationException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case NotSupportedException:
                    statusCode = HttpStatusCode.NotImplemented;
                    break;
                case ArgumentException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case UnauthorizedAccessException:
                    statusCode = HttpStatusCode.Unauthorized;
                    break;
                case ForbiddenAccessExeption:
                    statusCode = HttpStatusCode.Forbidden;
                    break;
                default:
                    break;
            }

            var errorTitle = string.Empty;
            switch (statusCode)
            {
                case (HttpStatusCode)500:
                    errorTitle = ErrorTitles.InternalServerError;
                    break;
                case (HttpStatusCode)404:
                    errorTitle = ErrorTitles.NotFound;
                    break;
                // more error titles below
            };

            // Set the response status code
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";
            // Add exception information into the JSON response body
            var response = new ErrorDetail()
            {
                // Title error can be applied with the corresponding status code
                Title = errorTitle,
                StatusCode = (int)statusCode,
                Message = ex.Message,
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
