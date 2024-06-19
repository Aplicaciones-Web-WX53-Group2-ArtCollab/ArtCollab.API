using System.Net.Mime;
using AutoMapper;
using Domain.Content.Models.Aggregate;
using Domain.Content.Models.Commands;
using Domain.Content.Models.Response;
using Infrastructure.Content.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Content.REST.Controllers
{
    [Route("api/v1/content/[controller]")]
    [ApiController]
    [Produces((MediaTypeNames.Application.Json))]
    [AllowAnonymous]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public class TemplateController(IMapper mapper, ITemplateData<Template> templateData) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly ITemplateData<Template> _templateData = templateData;
        
        // GET: api/v1/content/template/get-all-templates
       /// <summary>
       /// Get all templates
       /// </summary>
       /// <response code = "200">Return all templates</response>
       /// <response code = "404">Not found</response>
       /// <response code = "500">Internal Server Error</response>
       /// <response code = "400">Bad Request</response>
        [HttpGet]
        [Route("get-all-templates")]
        [ProducesResponseType(200)]
       [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllTemplates()
        {
            var templates = await _templateData.GetAllAsync();
            var result = _mapper.Map<IEnumerable<Template>, IEnumerable<TemplateResponse>>(templates);
            
            if (result == null) return NotFound();
            
            return Ok(result);
        }
        
        // GET: api/v1/content/template/get-template-by-id
      /// <summary>
      ///  Get template by id
      /// </summary>
      /// <response code="200">Return template by id</response>
      /// <response code="404">Not found</response>
      /// <response code="500">Internal Server Error</response>
      /// <response code="400">Bad Request</response>
        [HttpGet]
        [Route("get-template-by-id")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTemplateById(int id)
        {
            var template = await _templateData.GetByIdAsync(id);
            var result = _mapper.Map<Template, TemplateResponse>(template);
            
            if (result == null) return NotFound();
            
            return Ok(result);
        }
        
        // GET: api/v1/content/template/get-template-by-genre
       /// <summary>
       ///  Get template by genre
       /// </summary>
       /// <response code="200">Return template by genre</response>
       /// <response code="404">Not found</response>
       /// <response code="500">Internal Server Error</response>
       /// <response code="400">Bad Request</response>
        [HttpGet]
        [Route("get-template-by-genre")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTemplateByGenre(string genre)
        {
            var templates = await _templateData.GetByGenreAsync(genre);
            var result = _mapper.Map<IEnumerable<Template>, IEnumerable<TemplateResponse>>(templates);
    
            if (result == null || !result.Any()) return NotFound();
            
            return Ok(result);
        }
        
        // POST: api/v1/content/template/create-template
        /// <summary>
        /// Create a new template
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST api/v1/content/template/create-template
        /// {
        ///     "name": "Template name",
        ///     "description": "Template description",
        ///     "type": "Template type",
        ///     "imgUrl": "Template image url",
        ///     "genre": "Template genre"
        /// }
        /// </remarks>
        /// <response code="201">Returns the newly created template</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        [HttpPost]
        [Route("create-template")]
        [ProducesResponseType(201)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> CreateTemplate(CreateTemplateCommand data)
        {
                if(!ModelState.IsValid) return BadRequest();
                var template = _mapper.Map<CreateTemplateCommand, Template>(data);
                await _templateData.Add(template);
                return Ok(true);
        }
        
        // PUT: api/v1/content/template/update-template
        /// <summary>
        /// Update a template
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT api/v1/content/template/update-template
        /// {
        ///     "id": 1,
        ///     "name": "Template name",
        ///     "description": "Template description",
        ///     "type": "Template type",
        ///     "imgUrl": "Template image url",
        ///     "genre": "Template genre"
        /// }
        /// </remarks>
        [HttpPost]
        [Route("update-template")]
        public async Task<IActionResult> UpdateTemplate(Template data)
        {
                if(!ModelState.IsValid) return BadRequest();
                await _templateData.Update(data);
                return Ok(true);
        }
        
        // DELETE: api/v1/content/template/delete-template
        /// <summary>
        /// Delete a template
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE api/v1/content/template/delete-template?id=1
        /// </remarks>
        /// <response code="200">Returns true if the template was deleted</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="400">Bad Request</response>
        [HttpGet]
        [Route("delete-template")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteTemplate(int id)
        {
            await _templateData.Delete(id);
            return Ok(true);
        }
    }
}
