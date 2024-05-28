using System.Net.Mime;
using Domain.Monetization.Model.Aggregates;
using Domain.Monetization.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Monetization.REST.Controllers;

[Route("api/v1/monetization/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[AllowAnonymous]
public class CommisionController(IRepositoryGeneric<Commision> repositoryGeneric)  : ControllerBase
{
    private readonly IRepositoryGeneric<Commision> _repositoryGeneric = repositoryGeneric;
    [HttpGet]
    [Route("get-all")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repositoryGeneric.ListAsync());
    }
    
    [HttpPost]
    [Route("add-commision")]
    public async Task<IActionResult> Post([FromBody] Commision commision)
    {
        await _repositoryGeneric.AddAsync(commision);
        return Ok(true);
    }
    
    
}