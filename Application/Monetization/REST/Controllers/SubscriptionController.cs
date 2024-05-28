using System.Net.Mime;
using Domain.Monetization.Interface;
using Domain.Monetization.Model.Aggregates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Monetization.REST.Controllers;

[Route("api/v1/monetization/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[AllowAnonymous]
public class SubscriptionController(IRepositoryGeneric<Subscription> repositoryGeneric)  : ControllerBase
{
    private readonly IRepositoryGeneric<Subscription> _repositoryGeneric = repositoryGeneric;
    [HttpGet]
    [Route("get-all")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repositoryGeneric.GetAllAsync());
    }
    
    [HttpPost]
    [Route("add-subscription")]
    public async Task<IActionResult> Post([FromBody] Subscription subscription)
    {
        await _repositoryGeneric.Add(subscription);
        return Ok(true);
    }
}