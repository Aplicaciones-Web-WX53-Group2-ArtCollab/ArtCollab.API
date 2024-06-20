using Infrastructure.IAM.Pipeline.Middleware.Components;
using Microsoft.AspNetCore.Builder;

namespace Infrastructure.IAM.Pipeline.Middleware.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseRequestAuthorization(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestAuthorizationMiddleware>();
    }
}