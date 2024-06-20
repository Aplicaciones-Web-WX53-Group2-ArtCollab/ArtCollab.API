using System.Net.Mime;
using Domain.Collaboration.Model.Queries;
using Domain.Collaboration.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Collaboration.REST.Resources;
using Presentation.Collaboration.REST.Transform;

namespace Presentation.Collaboration.REST;

[Route("api/v1/collaboration/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[AllowAnonymous]
[ProducesResponseType(401)]
[ProducesResponseType(403)]
[ProducesResponseType(500)]
[ProducesResponseType(400)]
public class CommentController(ICommentCommandService commentCommandService, ICommentQueryService commentQueryService) : ControllerBase
{

        
    /// <summary>
    ///  Return all comments
    /// </summary>
    ///  <response code="200">Return all comments</response>
    /// <response code="404">Not found</response>
    /// <response code="500">Internal Server Error</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="403">Forbidden</response>
        
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetAllComments()
    {
        var query = new GetAllCommentsQuery();
        var comments = await commentQueryService.Handle(query);
        var commentResource = comments.Select(CommentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(commentResource);
    }
        
        
    /// <summary>
    /// Return comment by id
    /// </summary>
    /// <response code="200">Return comment by id</response>
    /// <response code="404">Not found</response>
    /// <response code="500">Internal Server Error</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="403">Forbidden</response>
        
    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetCommentById(int id)
    {
        var query = new GetCommentByIdQuery(id);
        var comment = await commentQueryService.Handle(query);
        var commentResource = CommentResourceFromEntityAssembler.ToResourceFromEntity(comment);
        return Ok(commentResource);
    }
        
    /// <summary>
    ///  Create a new comment
    /// </summary>
    /// <response code="201">Create a new comment</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="500">Internal Server Error</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="403">Forbidden</response>
        
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> PostComment([FromBody] CreateCommentResource createCommentResource)
    {
        var command = CreateCommentCommandFromResourceAssembler.ToCommandFromResource(createCommentResource);
        var comment = await commentCommandService.Handle(command);
        var commentResource = CommentResourceFromEntityAssembler.ToResourceFromEntity(comment);
        return StatusCode(201, commentResource);

    }
        
    /// <summary>
    ///  Update a comment
    /// </summary>
    /// <response code="200">Update a comment</response>
    /// <response code="404">Not found</response>
    /// <response code="500">Internal Server Error</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="403">Forbidden</response>
        
    [HttpPut("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> PutComment(int id,[FromBody] UpdateCommentResource updateCommentResource)
    {
        var command = UpdateCommentCommandFromResourceAssembler.ToCommandFromResource(id,updateCommentResource);
        var comment = await commentCommandService.Handle(command);
        var commentResource = CommentResourceFromEntityAssembler.ToResourceFromEntity(comment);
        return Ok(commentResource);
    }
        
        
    /// <summary>
    ///  Delete a comment
    /// </summary>
    /// <response code="200">Delete a comment</response>
    /// <response code="404">Not found</response>
    /// <response code="500">Internal Server Error</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="403">Forbidden</response>

    [HttpDelete("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteComment(int id)
    {
        var deleteCommentResource = new DeleteCommentResource(id);
        var command = DeleteCommentCommandFromResourceAssembler.ToCommandFromResource(deleteCommentResource);
        var comment = await commentCommandService.Handle(command);
        var commentResource = CommentResourceFromEntityAssembler.ToResourceFromEntity(comment);
        return Ok(commentResource);
    }
}