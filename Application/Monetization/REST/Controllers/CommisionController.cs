using System.Net.Mime;
using Domain.Interface;
using Infraestructure.Monetization.Model.Aggregates;
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
        return Ok(await _repositoryGeneric.GetAllAsync());
    }
    
    [HttpPost]
    [Route("add-commision")]
    public async Task<IActionResult> Post([FromBody] Commision commision)
    {
        await _repositoryGeneric.Add(commision);
        return Ok(true);
    }

    [HttpGet]
    [Route("get-by-id/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _repositoryGeneric.GetByIdAsync(id));
    }
    
    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> Update([FromBody] Commision commision)
    {
        await _repositoryGeneric.Update(commision);
        return Ok(true);
    }
    
    [HttpGet]
    [Route("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repositoryGeneric.Delete(id);
        return Ok(true);
    }
    
    
    
    
}