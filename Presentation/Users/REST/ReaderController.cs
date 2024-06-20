/*
using System.Net.Mime;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Users.Interfaces;
using Infrastructure.Users.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Users.Request;
using Presentation.Users.Response;

namespace Presentation.Users.REST.Controllers
{
    [Route("api/v1/users/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [AllowAnonymous]
    [ProducesResponseType(500)]
    [ProducesResponseType(400)]
    public class ReaderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReaderData _readerData;
        private readonly IRepositoryGeneric<Reader> _repositoryGeneric;

        public ReaderController(IReaderData readerData, IRepositoryGeneric<Reader> repositoryGeneric, IMapper mapper)
        {
            _readerData = readerData;
            _repositoryGeneric = repositoryGeneric;
            _mapper = mapper;
        }
        
        /// <summary>
        ///   Get a reader by email and password
        /// </summary>
        /// <response code="200">If the reader found</response>
        /// <response code="404">If the reader not found</response>
        /// <response code="500">If there is an internal server error</response>
        /// <response code="400" >If there is a bad request</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        // GET: api/Reader/5
        [HttpGet("{email}/{password}", Name = "GetByEmailAndPassword")]
        public async Task<IActionResult> GetByEmailAndPasswordAsync(string email, string password)
        {
            var readerId = await _readerData.GetByEmailAndPasswordAsync(email, password);

            if (readerId == null) return NotFound();

            return Ok(readerId);
        }
        
        /// <summary>
        ///  Get a reader by id
        /// </summary>
        /// <response code="200">If the reader found</response>
        /// <response code="404">If the reader not found</response>
        /// <response code="500">If there is an internal server error</response>
        /// <response code="400" >If there is a bad request</response>
        /// <returns></returns>
        /// 
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        // GET: api/Reader/5
        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data = await _readerData.GetByIdAsync(id);
            var result = _mapper.Map<Reader, ReaderResponse>(data);

            if (result == null) return NotFound();

            return Ok(result);
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
        [ProducesResponseType(401)]
        public async Task<IActionResult> PostAsync([FromBody] ReaderRequest data)
        {
                if (!ModelState.IsValid) return BadRequest();
                var reader = _mapper.Map<ReaderRequest, Reader>(data);
                await _repositoryGeneric.AddAsync(reader);
                var readerResponse = _mapper.Map<Reader, ReaderResponse>(reader);
                return Ok(readerResponse);
            }
        }
    }
    */
