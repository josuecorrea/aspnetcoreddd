using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project.Accounting.Service.Domain.Commom;
using System.Net;

namespace Project.Accounting.Service.Api.CustomMiddleware.Implements
{
    public class TimeOutExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<DefaultExceptionHandler> _logger;
        public TimeOutExceptionHandler(ILogger<DefaultExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "A timeout occurred");

            if (exception is TimeoutException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;

                var problemDetails = new ProblemDetails
                {
                    Status = (int)HttpStatusCode.RequestTimeout,
                    Type = exception.GetType().Name,
                    Title = "A timeout occurred",
                    Detail = exception.Message,
                    Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
                };

                await httpContext.Response.WriteAsJsonAsync(new BaseResult<ProblemDetails>(problemDetails, ["A timeout occurred"]));

                return true;
            }
            return false;
        }
    }
}