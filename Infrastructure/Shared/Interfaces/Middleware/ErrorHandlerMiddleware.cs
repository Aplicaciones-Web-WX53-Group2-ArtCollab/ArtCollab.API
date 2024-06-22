using System.Data;
using System.Net;
using Microsoft.AspNetCore.Http;
using Shared;

namespace Infrastructure.Shared.Interfaces.Middleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    
    public ErrorHandlerMiddleware(RequestDelegate next)
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
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = ex.Message;
        

        if (ex is ConstraintException || ex is DuplicateNameException || ex is TemplateWithTheSameTitleAlreadyExistException  )
        {
            code = HttpStatusCode.Conflict;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        await context.Response.WriteAsync(result);
    }
}