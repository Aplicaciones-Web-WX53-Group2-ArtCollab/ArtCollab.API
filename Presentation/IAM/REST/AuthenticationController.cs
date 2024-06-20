using System.Net.Mime;
using Domain.IAM.Model.Commands;
using Domain.IAM.Services;
using Infrastructure.IAM.Pipeline.Middleware.Attributes;
using Microsoft.AspNetCore.Mvc;
using Presentation.IAM.REST.Resources;
using Presentation.IAM.REST.Transform;

namespace Presentation.IAM.REST;

[ApiController]
[Authorize]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ProducesResponseType(400)]
[ProducesResponseType(500)]
public class AuthenticationController(IAdminCommandService adminCommandService) : ControllerBase
{
    /// <summary>
    ///   Sign up a new admin user
    /// </summary>
    /// <param name="signUpResource"></param>
    /// <response code="201">Admin created successfully</response>
    /// <response code="400">Bad request</response>
    /// <response code="500">Internal server error</response>
    [HttpPost("sign-up")]
    [AllowAnonymous]
    [ProducesResponseType(201)]
    public async Task<IActionResult> SignUp([FromBody] SignUpResource signUpResource)
    {
        var command = SignUpCommandFromResourceAssembler.ToCommandFromResource(signUpResource);
        await adminCommandService.Handle(command);
        return Ok( new { message = "Admin created successfully" });
    }
    
    /// <summary>
    ///  Sign in an admin user and return a token
    /// </summary>
    /// <param name="resource"></param>
    /// <response code = "200">Admin signed in successfully</response>
    /// <response code = "401">If user Unauthorized</response>
    /// <reponse code = "403">If user Forbidden</reponse>
    
    [HttpPost("sign-in")]
    [AllowAnonymous]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    public async Task<IActionResult> SignIn([FromBody] SignInResource resource)
    {
        var signInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(resource);
        var authenticatedUser = await adminCommandService.Handle(signInCommand);
        var authenticatedUserResource =
            AuthenticatedAdminResourceFromEntityAssembler.ToResourceFromEntity(authenticatedUser.admin,
                authenticatedUser.token);
        return Ok(authenticatedUserResource);
    }
}