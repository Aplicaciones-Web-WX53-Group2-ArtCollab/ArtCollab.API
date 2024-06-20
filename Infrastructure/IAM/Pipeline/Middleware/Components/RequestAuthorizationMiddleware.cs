using Application.IAM.Internal.OutboundServices;
using Domain.IAM.Model.Queries;
using Domain.IAM.Services;
using Infrastructure.IAM.Pipeline.Middleware.Attributes;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.IAM.Pipeline.Middleware.Components;

public class RequestAuthorizationMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(
        HttpContext context,
        IAdminQueryService userQueryService,
        ITokenService tokenService
    )
    {
        Console.WriteLine("Entering InvokeAsync");
        var allowAnonymous =
            context.Request.HttpContext.GetEndpoint()!.Metadata.Any(m =>
                m.GetType() == typeof(AllowAnonymousAttribute));
        Console.WriteLine($"Allow Anonymous is {allowAnonymous}");
        if (allowAnonymous)
        {
            Console.WriteLine("Skipping Authorization");
            await next(context);
            return;
        }
        Console.WriteLine("Checking Authorization");
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?
            .Split(" ").Last();
        if (token == null) throw new Exception("Null or invalid token");
        var userId = await tokenService.ValidateToken(token);
        if (userId == null) throw new Exception("Invalid token");
        var getUserByIdQuery = new GetAdminByIdQuery(userId.Value);
        var user = await userQueryService.Handle(getUserByIdQuery);
        if (user == null) throw new Exception("Admin not found");
        Console.WriteLine("Authorization successful");
        context.Items["User"] = user;
        Console.WriteLine("Continuing with Middleware pipeline");
        await next(context);
    }
}