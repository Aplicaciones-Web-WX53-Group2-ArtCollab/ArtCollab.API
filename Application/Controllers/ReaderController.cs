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

        // GET: api/Reader
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var data = await _readerData.GetAllAsync();
            var result = _mapper.Map<IEnumerable<Reader>, List<ReaderResponse>>(data);
            return Ok(result);
        }

        // GET: api/Reader/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var data = await _readerData.GetByIdAsync(id);
            var result = _mapper.Map<Reader, ReaderResponse>(data);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // GET: api/Reader/5
        [HttpGet("{email}", Name = "GetByEmail")]
        public async Task<IActionResult> GetByEmailAsync(string email)
        {
            var data = await _readerData.GetByEmailAsync(email);
            var result = _mapper.Map<Reader, ReaderResponse>(data);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // GET: api/Reader/5
        [HttpGet("{userName}/{password}", Name = "GetByUserNameAndPassword")]
        public async Task<IActionResult> GetByUserNameAndPasswordAsync(string userName, string password)
        {
            var data = await _readerData.GetByUserNameAndPasswordAsync(userName, password);
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

        // PUT: api/Reader/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] ReaderRequest value)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var reader = _mapper.Map<ReaderRequest, Reader>(value);
                await _repositoryGeneric.UpdateAsync(reader, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/Reader/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repositoryGeneric.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
