using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Request;
using Application.Response;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        // GET: api/Reader/5
        [HttpGet("{email}/{password}", Name = "GetByEmailAndPassword")]
        public async Task<IActionResult> GetByEmailAndPasswordAsync(string email, string password)
        {
            var data = await _readerData.GetByEmailAndPasswordAsync(email, password);
            var result = _mapper.Map<Reader, ReaderResponse>(data);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // POST: api/Reader
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ReaderRequest data)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var reader = _mapper.Map<ReaderRequest, Reader>(data);
                var result = await _repositoryGeneric.AddAsync(reader);
                return Created("api/Reader", result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
