using System.Net;
using NeoArchiveAI.Application.Exceptions;

namespace NeoArchiveAI.Api.Middleware;

public sealed class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            await context.Response.WriteAsJsonAsync(new
            {
                error = "ValidationError",
                message = exception.Message,
                details = exception.Errors
            });
        }
        catch (ConflictException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;

            await context.Response.WriteAsJsonAsync(new
            {
                error = "Conflict",
                message = exception.Message
            });
        }
        catch (NotFoundException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;

            await context.Response.WriteAsJsonAsync(new
            {
                error = "NotFound",
                message = exception.Message
            });
        }
        catch (Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsJsonAsync(new
            {
                error = "ServerError",
                message = exception.Message
            });
        }
    }
}
