using Application.Users.Request;
using Application.Users.Response;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Model;
using Infrastructure.Users.Interfaces;
using Infrastructure.Users.Model;
using Microsoft.AspNetCore.Mvc;

namespace Application.Users.Controllers
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
            var readerId = await _readerData.GetByEmailAndPasswordAsync(email, password);

            if (readerId == null) return NotFound();

            return Ok(readerId);
        }

        // GET: api/Reader/5
        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data = await _readerData.GetByIdAsync(id);
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
