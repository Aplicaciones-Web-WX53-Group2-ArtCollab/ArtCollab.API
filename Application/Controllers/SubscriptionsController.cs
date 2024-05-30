using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Domain.Interfaces;
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
    public class SubscriptionsController(ISubscriptionDomain<Subscription> subscriptionDomain) : ControllerBase
    {
        private readonly ISubscriptionDomain<Subscription> _subscriptionDomain = subscriptionDomain;
        
        [HttpGet]
        [Route("get-all-subscriptions")]
        public async Task<IActionResult> GetAllTemplates()
        {
            var templates = await _subscriptionDomain.GetAllAsync();
            return Ok(templates);
        }
        
        [HttpGet]
        [Route("get-subscription-by-id")]
        public async Task<IActionResult> GetTemplateById(int id)
        {
            var template = await _subscriptionDomain.GetByIdAsync(id);
            return Ok(template);
        }
        
        [HttpPost]
        [Route("create-subscriptions")]
        public async Task<IActionResult> CreateTemplate(Subscription data)
        {
            await _subscriptionDomain.Add(data);
            return Ok(true);
        }
        
        [HttpGet]
        [Route("delete-subscriptions")]
        public async Task<IActionResult> DeleteTemplate(int id)
        {
            await _subscriptionDomain.Delete(id);
            return Ok(true);
        }
        
        [HttpPost]
        [Route("update-subscription")]
        public async Task<IActionResult> UpdateTemplate(Subscription data)
        {
            await _subscriptionDomain.Update(data);
            return Ok(true);
        }
    }
}
