using System.Net.Mime;
using AutoMapper;
using Domain.Content.Model.Queries;
using Domain.Content.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Content.REST.Resources;
using Presentation.Content.REST.Transform;

namespace Presentation.Content.REST
{
    [Route("api/v1/content/[controller]")]
    [ApiController]
    [Produces((MediaTypeNames.Application.Json))]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    public class TemplateController(
        ITemplateCommandService templateCommandService,
        ITemplateQueryService templateQueryService) : ControllerBase
    {

        // GET: api/v1/content/template/get-all-templates
        /// <summary>
        /// Get all templates
        /// </summary>
        /// <response code = "200">Return all templates</response>
        /// <response code = "404">Not found</response>
        /// <response code = "500">Internal Server Error</response>
        /// <response code = "400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllTemplates()
        {
            var query = new GetAllTemplatesQuery();
            var templates = await templateQueryService.Handle(query);
            var templateResource = templates.Select(TemplateResourceFromEntityAssembler.ToResourceFromEntity).ToList();
            return Ok(templateResource);
        }

        // GET: api/v1/content/template/get-template-by-id
        /// <summary>
        ///  Get template by id
        /// </summary>
        /// <response code="200">Return template by id</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTemplateById(int id)
        {
            var query = new GetTemplateByIdQuery(id);
            var template = await templateQueryService.Handle(query);
            var templateResource = TemplateResourceFromEntityAssembler.ToResourceFromEntity(template);
            return Ok(templateResource);
        }

        // GET: api/v1/content/{genre}
        /// <summary>
        ///  Get templates by genre
        /// </summary>
        /// <response code="200">Return template by genre</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        [HttpGet]
        [Route("genre/{genre}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTemplatesByGenre(string genre)
        {
            var query = new GetTemplatesByGenreQuery(genre);
            var templates = await templateQueryService.Handle(query);
            var templateResource = templates.Select(TemplateResourceFromEntityAssembler.ToResourceFromEntity).ToList();
            return Ok(templateResource);
        }
       
        // GET: api/v1/content/{imgUrl}
        /// <summary>
        ///  Get template by cover image
        /// </summary>
        /// <response code="200">Return template by cover image</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        [HttpGet]
        [Route("coverImage/{imgUrl}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTemplateByCoverImage(string imgUrl)
        {
            var query = new GetTemplateByCoverImageQuery(imgUrl);
            var template = await templateQueryService.Handle(query);
            var templateResource = TemplateResourceFromEntityAssembler.ToResourceFromEntity(template);
            return Ok(templateResource);
        }
        
        
        // GET: api/v1/content/{imgUrl}
        /// <summary>
        ///  Get template by description
        /// </summary>
        /// <response code="200">Return template by description</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        [HttpGet]
        [Route("description/{description}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTemplateByDescription(string description)
        {
            var query = new GetTemplateByDescriptionQuery(description);
            var template = await templateQueryService.Handle(query);
            var templateResource = TemplateResourceFromEntityAssembler.ToResourceFromEntity(template);
            return Ok(templateResource);
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
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> CreateTemplate([FromBody] CreateTemplateResource createTemplateResource)
        {
            var command = CreateTemplateCommandFromResourceAssembler.ToResourceFromEntity(createTemplateResource);
            var template = await templateCommandService.Handle(command);
            var templateResource = TemplateResourceFromEntityAssembler.ToResourceFromEntity(template);
            return StatusCode(201, templateResource);
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
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="200">Returns the updated template</response>
        /// <reponse code = "404">Not found</reponse>
        /// <reponse code = "500">Internal Server Error</reponse>
        /// <reponse code = "400">Bad Request</reponse>
        [HttpPut ("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateTemplate(int id, [FromBody] UpdateTemplateResource resource)
        {
            var command = UpdateTemplateCommandFromResourceAssembler.ToCommandFromResource(id,resource);
            var template = await templateCommandService.Handle(command);
            var templateResource = TemplateResourceFromEntityAssembler.ToResourceFromEntity(template);
            return Ok(templateResource);
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
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteTemplate(int id)
        {
            var deleteTemplateResource = new DeleteTemplateResource(id);
            var command = DeleteTemplateCommandFromResourceAssembler.ToCommandFromResource(deleteTemplateResource);
            var template = await templateCommandService.Handle(command);
            var templateResource = TemplateResourceFromEntityAssembler.ToResourceFromEntity(template);
            return Ok(templateResource);
        }
    }
}
