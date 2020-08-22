using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WorkoutPlanner.Errors;

namespace WorkoutPlanner.Middlewares {
    public class ExceptionMiddleware {
        private readonly RequestDelegate _next;
        private readonly  ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger) {
            _next = next;
            _logger = logger;
        }
        
        public async Task InvokeAsync(HttpContext httpContext) {
            try {
                await _next(httpContext);
            } catch(GenericError error) {
                _logger.LogError($"Something went wrong: {error.Message}");
                await HandleExceptionAsync(httpContext, error);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, GenericError error) {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)error.StatusCode;

            return context.Response.WriteAsync(new ErrorDetails() {
                message = error.Message,
                id = error.Id
            }.ToString());
        }
    }
}