using System.Collections;
using System.Net.Mime;
using Application.Monetization.Request;
using Application.Monetization.Response;
using AutoMapper;
using Domain.Interface;
using Infraestructure.Monetization.Model.Aggregates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Monetization.REST.Controllers;

[Route("api/v1/monetization/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[AllowAnonymous]
public class CommisionController(IRepositoryGeneric<Commision> repositoryGeneric, IMapper mapper )  : ControllerBase
{
    private readonly IRepositoryGeneric<Commision> _repositoryGeneric = repositoryGeneric;
    private readonly IMapper _mapper = mapper;
    [HttpGet]
    [Route("get-all")]
    public async Task<IActionResult> GetAll()
    {
       var commisions = await _repositoryGeneric.GetAllAsync();
       var result = _mapper.Map<IEnumerable<Commision>, IEnumerable<CommisionResponse>>(commisions);

       if (result == null) return NotFound();

       return Ok(result);
    }
    
    [HttpPost]
    [Route("add-commision")]
    public async Task<IActionResult> Post([FromBody] CommisionRequest commisionRequest)
    {
        var commision = _mapper.Map<CommisionRequest, Commision>(commisionRequest);
        await _repositoryGeneric.Add(commision);
        return Ok(true);
    }

    [HttpGet]
    [Route("get-by-id/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
       var commision = await _repositoryGeneric.GetByIdAsync(id);
       var result = _mapper.Map<Commision, CommisionResponse>(commision);
       if(result == null) return NotFound();

       return Ok(result);
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