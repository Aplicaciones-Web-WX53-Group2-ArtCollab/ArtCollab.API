using System.Net.Mime;
using Domain.User.Model.Commands;
using Domain.User.Model.Queries;
using Domain.User.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Users.REST.Resources;
using Presentation.Users.REST.Transform;

namespace Presentation.Users.REST
{
    [Route("api/v1/reader/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(500)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    public class ReaderController(IReaderCommandService readerCommandService, IReaderQueryService readerQueryService)
        : ControllerBase
    {
        /// <summary>
        ///   Get a reader by email and password
        /// </summary>
        /// <response code="200">If the reader found</response>
        /// <response code="404">If the reader not found</response>
        /// <response code="500">If there is an internal server error</response>
        /// <response code="400" >If there is a bad request</response>
        /// <response code="401">If the user is not authenticated</response>
        /// <response code="403">If the user is not authorized</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        // GET: api/Reader/5
        [HttpGet]
        public async Task<IActionResult> GetAllReaders()
        {
            var query = new GetAllReadersQuery();
            var readers = await readerQueryService.Handle(query);
            var readerResource = readers.Select(ReaderResourceFromEntityAssembler.ToResourceFromEntity).ToList();
            return Ok(readerResource);
        }

        /// <summary>
        ///  Get a reader by id
        /// </summary>
        /// <response code="200">If the reader found</response>
        /// <response code="404">If the reader not found</response>
        /// <response code="500">If there is an internal server error</response>
        /// <response code="400" >If there is a bad request</response>
        /// <response code="401">If the user is not authenticated</response>
        /// <response code="403">If the user is not authorized</response>
        /// 
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        // GET: api/Reader/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var command = new GetReaderByIdQuery(id);
            var reader = await readerQueryService.Handle(command);
            if (reader == null) return NotFound();
            var readerResource = ReaderResourceFromEntityAssembler.ToResourceFromEntity(reader);
            return Ok(readerResource);
        }

        /// <summary>
        ///  Add a new reader
        /// </summary>
        /// <response code="201">If the reader is created</response>
        /// <response code="500">If there is an internal server error</response>
        /// <response code="400" >If there is a bad request</response>
        /// <response  code="401">If the user is not authorized</response>
        /// <returns></returns>
        ///
        // POST: api/Reader
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateReader([FromBody] CreateReaderResource createReaderResource)
        {
            var command = CreateReaderCommandFromResourceAssembler.ToCommandFromResource(createReaderResource);
            var reader = await readerCommandService.Handle(command);
            var readerResource = ReaderResourceFromEntityAssembler.ToResourceFromEntity(reader);
            return StatusCode(201, readerResource);
        }
        /// <summary>
        ///  Update a reader by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateReaderResource"></param>
        /// <response code="200">If the reader is updated</response>
        /// <response code="404">If the reader not found</response>
        /// <response code="500">If there is an internal server error</response>
        /// <response code="400" >If there is a bad request</response>
        /// <response code="401">If the user is not authorized</response>
        /// <response code="403">If the user forbbiden </response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateReader(int id,[FromBody] UpdateReaderResource updateReaderResource)
        {
            var command = UpdateReaderCommandFromResourceAssembler.ToCommandFromResource(id,updateReaderResource);
            var reader = await readerCommandService.Handle(command);
            if (reader == null) return NotFound();
            var readerResource = ReaderResourceFromEntityAssembler.ToResourceFromEntity(reader);
            return Ok(readerResource);
        }
        
        /// <summary>
        ///  Delete a reader by id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">If the reader is deleted</response>
        /// <response code="404">If the reader not found</response>
        /// <reponse code="500">If there is an internal server error</reponse>
        /// <response code="400" >If there is a bad request</response>
        /// <response code="401">If the user is not authorized</response>
        /// <response code="403">If the user forbbiden </response>
        
        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteReader(int id)
        {
            var command = new DeleteReaderCommand(id);
            var reader = await readerCommandService.Handle(command);
            if (reader == null) return NotFound();
            var readerResource = ReaderResourceFromEntityAssembler.ToResourceFromEntity(reader);
            return Ok(readerResource);
        }
        
    }
}
