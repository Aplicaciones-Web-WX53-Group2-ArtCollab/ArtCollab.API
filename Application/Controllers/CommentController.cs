using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Request;
using Application.Response;
using AutoMapper;
using Domain;
using Infraestructure;
using Infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentData _commentData;

        private readonly ICommentDomain _commentDomain;

        private readonly IMapper _mapper;
        
        public CommentController(ICommentData commentData, ICommentDomain commentDomain, IMapper mapper)
        {
            _commentData = commentData;
            _commentDomain = commentDomain;
            _mapper = mapper;
        }
        
        // GET: api/Comment
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var data = await _commentData.getAllCommentAsync();
            var result = _mapper.Map<List<Comment>, List<CommentResponse>>(data);
            return Ok(result);
        }

        // GET: api/Comment/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _commentData.getByIdCommentAsync(id);
            var result = _mapper.Map<Comment, CommentResponse>(data);
            
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/Comment/Async
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CommentRequest data)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                var comment = _mapper.Map<CommentRequest, Comment>(data);
        
                try
                {
                    var result = await _commentDomain.SaveCommentAsync(comment);
                    return Created("api/comment", result);
                }
                catch (DbUpdateException ex)
                {
                    // Update this to your logging framework
                    Console.WriteLine($"An error occurred while saving changes: {ex.InnerException.Message}");
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException.Message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Comment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CommentRequest data)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                var comment = _mapper.Map<CommentRequest, Comment>(data);
                var result = await _commentDomain.UpdateCommentAsync(comment, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commentDomain.DeleteCommentAsync(id);
            return Ok();
        }
    }
}
