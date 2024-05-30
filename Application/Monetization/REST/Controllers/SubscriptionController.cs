using System.Net.Mime;
using Domain.Interface;
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


    [HttpGet]
    [Route("get-by-id/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _repositoryGeneric.GetByIdAsync(id));
    }
    
    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> Update([FromBody] Subscription subscription)
    {
        await _repositoryGeneric.Update(subscription);
        return Ok(true);
    }

    [HttpGet]
    [Route("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repositoryGeneric.Delete(id);
        return Ok(true);
    }

    [HttpPost]
    [Route("add-subscription")]
    public async Task<IActionResult> Post([FromBody] Subscription subscription)
    {
        await _repositoryGeneric.Add(subscription);
        return Ok(true);
    }
}