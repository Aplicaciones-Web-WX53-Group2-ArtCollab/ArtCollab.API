using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Domain.Interfaces;
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
    public class TemplateController(IRepositoryGeneric<Template> repositoryGeneric) : ControllerBase
    {
        private readonly IRepositoryGeneric<Template> _repositoryGeneric = repositoryGeneric;
        
        [HttpGet]
        [Route("get-all-templates")]
        public async Task<IActionResult> GetAllTemplates()
        {
            var templates = await _repositoryGeneric.GetAllAsync();
            return Ok(templates);
        }
        
        [HttpGet]
        [Route("get-template-by-id")]
        public async Task<IActionResult> GetTemplateById(int id)
        {
            var template = await _repositoryGeneric.GetByIdAsync(id);
            return Ok(template);
        }
        
        [HttpPost]
        [Route("create-template")]
        public async Task<IActionResult> CreateTemplate(Template data)
        {
            await _repositoryGeneric.Add(data);
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
