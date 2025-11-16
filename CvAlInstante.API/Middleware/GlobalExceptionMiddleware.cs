using System.Net;
using System.Text.Json;

namespace CvAlInstante.API.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var error = new ErrorResponse("An unexpected error occurred", ex.Message);
            await context.Response.WriteAsync(JsonSerializer.Serialize(error));
        }
    }
}
