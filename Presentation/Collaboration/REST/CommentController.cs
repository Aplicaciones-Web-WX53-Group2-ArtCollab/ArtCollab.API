using System.Net.Mime;
using AutoMapper;
using Domain.Collaboration.Model.Aggregates;
using Domain.Collaboration.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Collaboration.REST;

[Route("api/v1/collaboration/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[AllowAnonymous]
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
        
    [HttpGet]
    [Route("get-all-comments")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetAllComments()
    {
        var comments = await _repository.GetAllAsync();
        var result = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentResponse>>(comments);
        return Ok(result);
    }
        
        
    /// <summary>
    /// Return comment by id
    /// </summary>
    /// <response code="200">Return comment by id</response>
    /// <response code="404">Not found</response>
    /// <response code="500">Internal Server Error</response>
    /// <response code="400">Bad Request</response>
    /// <returns></returns>
        
    [HttpGet]
    [Route("get-comment-by-id")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetCommentById(int id)
    {
        var comment = await _repository.GetByIdAsync(id);
        var result = _mapper.Map<Comment, CommentResponse>(comment);
            
        if (result == null) return NotFound();
        return Ok(result);
    }
        
    /// <summary>
    ///  Create a new comment
    /// </summary>
    /// <response code="201">Create a new comment</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="500">Internal Server Error</response>
    /// <response code="400">Bad Request</response>
    /// <returns></returns>
        
    [HttpPost]
    [Route("create-comment")]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> PostComment([FromBody] CommentRequest data)
    {
        var comment = _mapper.Map<CommentRequest, Comment>(data);
        await _repository.AddAsync(comment);
        var commentResponse = _mapper.Map<Comment, CommentResponse>(comment);
        return Ok(commentResponse);
    }
        
    /// <summary>
    ///  Update a comment
    /// </summary>
    /// <response code="200">Update a comment</response>
    /// <response code="404">Not found</response>
    /// <response code="500">Internal Server Error</response>
    /// <response code="400">Bad Request</response>
    /// <returns></returns>
        
    [HttpPost]
    [Route("update-comment")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> PutCommnent([FromBody] CommentRequest data)
    {
        var comment = _mapper.Map<CommentRequest, Comment>(data);
        await _repository.UpdateAsync(comment);
        return Ok();
    }
        
        
    /// <summary>
    ///  Delete a comment
    /// </summary>
    /// <response code="200">Delete a comment</response>
    /// <response code="404">Not found</response>
    /// <response code="500">Internal Server Error</response>
    /// <response code="400">Bad Request</response>
    /// <returns></returns>

    [HttpGet]
    [Route("delete-comment")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteComment(int id)
    {
        await _repository.DeleteAsync(id);
        return Ok();
    }
}