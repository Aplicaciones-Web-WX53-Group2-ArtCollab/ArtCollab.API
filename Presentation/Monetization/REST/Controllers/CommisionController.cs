using System.Net.Mime;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Monetization.Model.Aggregates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Monetization.Request;
using Presentation.Monetization.Response;

namespace Presentation.Monetization.REST.Controllers;

[Route("api/v1/monetization/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[AllowAnonymous]
[ProducesResponseType(500)]
public class CommisionController(IRepositoryGeneric<Commision> repositoryGeneric, IMapper mapper )  : ControllerBase
{
    private readonly IRepositoryGeneric<Commision> _repositoryGeneric = repositoryGeneric;
    private readonly IMapper _mapper = mapper;
    
    // GET: api/v1/monetization/commision/get-all
    /// <summary>
    /// Return all commisions
    /// </summary>
    /// <response code="200">Return all commisions</response>
    /// <response code="404">If there are no commisions</response>
    /// <response code="500">If there is an internal error</response>
    [HttpGet]
    [Route("get-all")]
    [ProducesResponseType(404)]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetAll()
    {
       var commisions = await _repositoryGeneric.GetAllAsync();
       var result = _mapper.Map<IEnumerable<Commision>, IEnumerable<CommisionResponse>>(commisions);

       if (result == null) return NotFound();

       return Ok(result);
    }
    
    // POST: api/v1/monetization/commision/add-commision
    /// <summary>
    /// Add a new commision
    /// </summary>
    /// <response code="201">If the commision was added successfully</response>
    /// <response code="500">If there is an internal error</response>
    
    [HttpPost]
    [Route("add-commision")]
    [ProducesResponseType(201)]
    public async Task<IActionResult> Post([FromBody] CommisionRequest commisionRequest)
    {
        var commision = _mapper.Map<CommisionRequest, Commision>(commisionRequest);
        await _repositoryGeneric.AddAsync(commision);
        var commisionResponse = _mapper.Map<Commision, CommisionResponse>(commision);
        return StatusCode(201, commisionResponse);
    }
    
    // GET: api/v1/monetization/commision/get-by-id/{id}
    /// <summary>
    /// Return a commision by id
    /// </summary>
    /// <response code="200">Return a commision by id</response>
    /// <response code="404">If the commision was not found</response>
    /// <response code="500">If there is an internal error</response>

    [HttpGet]
    [Route("get-by-id/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
       var commision = await _repositoryGeneric.GetByIdAsync(id);
       var result = _mapper.Map<Commision, CommisionResponse>(commision);
       if(result == null) return NotFound();
       return Ok(result);
    }
    
    // POST: api/v1/monetization/commision/update
    /// <summary>
    /// Update a commision
    /// </summary>
    ///  <response code="200">If the commision was updated successfully</response>
    ///  <response code="404">If the commision to Update not found</response>
    ///  <response code="500">If there is an internal error</response>
    
    
    [HttpPost]
    [Route("update")]
    [ProducesResponseType(404)]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Update([FromBody] Commision commision)
    {
        var commisionToUpdate = await _repositoryGeneric.GetByIdAsync(commision.Id);
        if (commisionToUpdate == null) return NotFound();
        await _repositoryGeneric.Update(commisionToUpdate);
        var subscriptionResponse = _mapper.Map<Commision, CommisionResponse>(commisionToUpdate);
        return Ok(subscriptionResponse);
    }
    
    // GET: api/v1/monetization/commision/delete/{id}
    /// <summary>
    /// Delete a commision
    /// </summary>
    ///  <response code="200">If the commision was deleted successfully</response>
    ///  <response code="500">If there is an internal error</response>
    ///  <response code="404">If the commision was not found</response>
    
    [HttpGet]
    [Route("delete/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        var commisionToDelete = await _repositoryGeneric.GetByIdAsync(id);
        if (commisionToDelete == null) return NotFound();
        await _repositoryGeneric.Delete(id);
        var commisionResponse = _mapper.Map<Commision, CommisionResponse>(commisionToDelete);
        return Ok(commisionResponse);
    }
    
    
    
    
}