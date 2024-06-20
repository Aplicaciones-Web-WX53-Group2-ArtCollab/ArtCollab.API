using System.Net.Mime;
using Domain.IAM.Model.Queries;
using Domain.IAM.Services;
using Infrastructure.IAM.Pipeline.Middleware.Attributes;
using Microsoft.AspNetCore.Mvc;
using Presentation.IAM.REST.Transform;

namespace Presentation.IAM.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[ProducesResponseType(404)]
[ProducesResponseType(500)]
[ProducesResponseType(401)]
[ProducesResponseType(403)]
[ProducesResponseType(400)]
[Produces(MediaTypeNames.Application.Json)]
public class AdminController(IAdminQueryService adminQueryService) : ControllerBase
{
    /// <summary>
    ///  Get admin by username
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Admin found</response>
    /// <response code="404">Admin not found</response>
    /// <response code="500">Internal server error</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="403">Forbidden</response>
    [ProducesResponseType(200)]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAdminById(int id)
    {
        var getAdminByIdQuery = new GetAdminByIdQuery(id);
        var admin = await adminQueryService.Handle(getAdminByIdQuery);
        if (admin is null) return NotFound();
        var adminResource = AdminResourceFromEntityAssembler.ToResourceFromEntity(admin);
        return Ok(adminResource);
    }
    /// <summary>
    ///  Get all admin users
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Admin found</response>
    /// <response code="404">Admin not found</response>
    /// <response code="500">Internal server error</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="403">Forbidden</response>
    [ProducesResponseType(200)]
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var getAllAdminsQuery = new GetAllAdminsQuery();
        var users = await adminQueryService.Handle(getAllAdminsQuery);
        var userResources = users.Select(AdminResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(userResources);
    }
}