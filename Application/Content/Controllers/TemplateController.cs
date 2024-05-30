using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Application.Request;
using Application.Response;
using AutoMapper;
using Domain.Interfaces;
using Infraestructure.Content.Interfaces;
using Infraestructure.Interfaces;
using Infraestructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces((MediaTypeNames.Application.Json))]
    [AllowAnonymous]
    public class TemplateController(IRepositoryGeneric<Template> repositoryGeneric, IMapper mapper, ITemplateData<Template> templateData, IRepository<Template> repository) : ControllerBase
    {
        private readonly IRepositoryGeneric<Template> _repositoryGeneric = repositoryGeneric;
        private readonly IMapper _mapper = mapper;
        private readonly ITemplateData<Template> _templateData = templateData;
        private readonly IRepository<Template> _repository = repository;
        
        [HttpGet]
        [Route("get-all-templates")]
        public async Task<IActionResult> GetAllTemplates()
        {
            var templates = await _repository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<Template>, IEnumerable<TemplateResponse>>(templates);
            
            if (result == null) return NotFound();
            
            return Ok(result);
        }
        
        [HttpGet]
        [Route("get-template-by-id")]
        public async Task<IActionResult> GetTemplateById(int id)
        {
            var template = await _repository.GetByIdAsync(id);
            var result = _mapper.Map<Template, TemplateResponse>(template);
            
            if (result == null) return NotFound();
            
            return Ok(result);
        }
        
        [HttpGet]
        [Route("get-template-by-genre")]
        public async Task<IActionResult> GetTemplateByGenre(string genre)
        {
            var templates = await _templateData.GetByGenreAsync(genre);
            var result = _mapper.Map<IEnumerable<Template>, IEnumerable<TemplateResponse>>(templates);
    
            if (result == null || !result.Any()) return NotFound();
            
            return Ok(result);
        }
        
        [HttpGet]
        [Route("get-template-by-description")]
        public async Task<IActionResult> GetTemplateByDescription(string description)
        {
            var templates = await _templateData.GetByDescriptionAsync(description);
            var result = _mapper.Map<IEnumerable<Template>, IEnumerable<TemplateResponse>>(templates);
    
            if (result == null || !result.Any()) return NotFound();
            
            return Ok(result);
        }
        
        [HttpGet]
        [Route("get-template-by-cover-image")]
        public async Task<IActionResult> GetTemplateByCoverImage(string imgUrl)
        {
            var templates = await _templateData.GetByCoverImageAsync(imgUrl);
            var result = _mapper.Map<IEnumerable<Template>, IEnumerable<TemplateResponse>>(templates);
    
            if (result == null || !result.Any()) return NotFound();
            
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-template")]
        public async Task<IActionResult> CreateTemplate(TemplateRequest data)
        {
            var template = _mapper.Map<TemplateRequest, Template>(data);
            await _repositoryGeneric.Add(template);
            return Ok(true);
        }
        
        [HttpGet]
        [Route("delete-template")]
        public async Task<IActionResult> DeleteTemplate(int id)
        {
            await _repositoryGeneric.Delete(id);
            return Ok(true);
        }
        
        [HttpPost]
        [Route("update-template")]
        public async Task<IActionResult> UpdateTemplate(Template data)
        {
            await _repositoryGeneric.Update(data);
            return Ok(true);
        }
    }
}
