using Domain.IAM.Model.Aggregates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Infrastructure.IAM.Pipeline.Middleware.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
        {
            Console.WriteLine("Skipping Authorization");
            return;
        }
        // If admin is logged in, this will be set
        var admin = (Admin?)context.HttpContext.Items["Admin"];

        if (admin == null) context.Result = new UnauthorizedResult();
    }
}