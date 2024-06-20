using System.Net.Mime;
using AutoMapper;
using Domain.Monetization.Model.Aggregates;
using Domain.Monetization.Model.Commands;
using Domain.Monetization.Model.Queries;
using Domain.Monetization.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Monetization.REST.Resources;
using Presentation.Monetization.REST.Transform;

namespace Presentation.Monetization.REST;

[Route("api/v1/monetization/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[AllowAnonymous]
[ProducesResponseType(500)]
public class CommisionController(ICommisionCommandService commisionCommandService, ICommisionQueryService commisionQueryService )  : ControllerBase
{
  
    
    // GET: api/v1/monetization/commision/get-all
    /// <summary>
    /// Return all commisions
    /// </summary>
    /// <response code="200">Return all commisions</response>
    /// <response code="404">If there are no commisions</response>
    /// <response code="500">If there is an internal error</response>
    [HttpGet]
    [ProducesResponseType(404)]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllCommisionsQuery();
        var commisions = await commisionQueryService.Handle(query);
        var commisionResource = commisions.Select(CommisionResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(commisionResource);
    }
    
    // POST: api/v1/monetization/commision/add-commision
    /// <summary>
    /// Add a new commision
    /// </summary>
    /// <response code="201">If the commision was added successfully</response>
    /// <response code="500">If there is an internal error</response>
    
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult> Post([FromBody] CreateCommisionResource createCommisionResource)
    {
        var command = CreateCommisionCommandFromResourceAssembler.ToCommandFromResource(createCommisionResource);
        var commision = await commisionCommandService.Handle(command);
        var commisionResource = CommisionResourceFromEntityAssembler.ToResourceFromEntity(commision);
        return StatusCode(201, commisionResource);
    }
    
    // GET: api/v1/monetization/commision/get-by-id/{id}
    /// <summary>
    /// Return a commision by id
    /// </summary>
    /// <response code="200">Return a commision by id</response>
    /// <response code="404">If the commision was not found</response>
    /// <response code="500">If there is an internal error</response>

    [HttpGet("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetCommisionByIdQuery(id);
        var commision = await commisionQueryService.Handle(query);
        if (commision == null) return NotFound();
        var commisionResource = CommisionResourceFromEntityAssembler.ToResourceFromEntity(commision);
        return Ok(commisionResource);
    }
    
    // POST: api/v1/monetization/commision/update
    /// <summary>
    /// Update a commision
    /// </summary>
    ///  <response code="200">If the commision was updated successfully</response>
    ///  <response code="404">If the commision to Update not found</response>
    ///  <response code="500">If there is an internal error</response>
    
    
    [HttpPut("{id:int}")]
    [ProducesResponseType(404)]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Update(int id,[FromBody] UpdateCommisionResource updateCommisionResource)
    {
        var command = UpdateCommisionCommandFromResourceAssembler.ToCommandFromResource(id,updateCommisionResource);
        var updatedCommision = await commisionCommandService.Handle(command);
        if (updatedCommision == null) return NotFound();
        var commisionResource = CommisionResourceFromEntityAssembler.ToResourceFromEntity(updatedCommision);
        return Ok(commisionResource);
    }
    
    // GET: api/v1/monetization/commision/delete/{id}
    /// <summary>
    /// Delete a commision
    /// </summary>
    ///  <response code="200">If the commision was deleted successfully</response>
    ///  <response code="500">If there is an internal error</response>
    ///  <response code="404">If the commision was not found</response>
    
    [HttpDelete("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteCommisionCommand(id);
        var deletedCommision = await commisionCommandService.Handle(command);
        if (deletedCommision == null) return NotFound();
        var commisionResource = CommisionResourceFromEntityAssembler.ToResourceFromEntity(deletedCommision);
        return Ok(commisionResource);
    }
    
    
    
    
}