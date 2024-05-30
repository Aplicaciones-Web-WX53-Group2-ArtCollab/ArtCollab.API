using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Domain.Interfaces;
using Infraestructure.Interfaces;
using Infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces((MediaTypeNames.Application.Json))]
    public class SubscriptionsController(ISubscriptionDomain<Subscription> subscriptionDomain) : ControllerBase
    {
        private readonly ISubscriptionDomain<Subscription> _subscriptionDomain = subscriptionDomain;
        // GET: api/Subscriptions
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Subscriptions/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Subscriptions
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Subscriptions/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Subscriptions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
