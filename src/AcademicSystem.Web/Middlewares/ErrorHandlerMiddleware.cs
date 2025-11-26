using System.Net;
using System.Text.Json;
using AcademicSystem.ApplicationCore.Exceptions;

namespace AcademicSystem.Web.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            switch (error)
            {
                case DomainException e:
                    _logger.LogWarning(e, "Domain validation error");
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                
                default:
                    _logger.LogError(error, "An unhandled exception occurred");
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(new { message = error.Message });
            await response.WriteAsync(result);
        }
    }
}
