using System.Text.Json;
using Vagabond.Api.Exceptions;

namespace Vagabond.Api.Middleware;

public class GlobalExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (DestinationNotFoundException ex)
        {
            await WriteErrorResponseAsync(context, StatusCodes.Status404NotFound, ex.Message);
        }
        catch (Exception)
        {
            await WriteErrorResponseAsync(
                context,
                StatusCodes.Status500InternalServerError,
                "An unexpected error occurred. Please try again later.");
        }
    }

    private static async Task WriteErrorResponseAsync(HttpContext context, int statusCode, string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var payload = JsonSerializer.Serialize(new
        {
            StatusCode = statusCode,
            Message = message
        });

        await context.Response.WriteAsync(payload);
    }
}
