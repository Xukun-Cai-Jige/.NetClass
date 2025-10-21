using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MovieShopMVC.Middlewares;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MovieShopMVC.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MovieShopExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MovieShopExceptionMiddleware> _logger;

        public MovieShopExceptionMiddleware(RequestDelegate next, ILogger<MovieShopExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Unhandled exception at {Path} {Method} | User: {User} | CorrelationId: {TraceId} | UTC: {UtcNow}",
                    httpContext.Request.Path,
                    httpContext.Request.Method,
                    httpContext.User?.Identity?.IsAuthenticated == true ? httpContext.User.Identity!.Name : "Anonymous",
                    httpContext.TraceIdentifier,
                    DateTime.UtcNow);
                using (_logger.BeginScope(new Dictionary<string, object?>
                {
                    ["Path"] = httpContext.Request.Path.Value,
                    ["QueryString"] = httpContext.Request.QueryString.Value,
                    ["UserAgent"] = httpContext.Request.Headers.UserAgent.ToString(),
                    ["RemoteIp"] = httpContext.Connection.RemoteIpAddress?.ToString()
                }))
                {
                    _logger.LogError("Extra request context captured.");
                }

                if (!httpContext.Response.HasStarted)
                {

                    httpContext.Response.Clear();
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    httpContext.Response.Redirect("/home/error");
                }
            }
        }
        }
    

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MovieShopExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMovieShopExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MovieShopExceptionMiddleware>();
        }
    }
}
