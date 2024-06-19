using System.Net.Mime;
using AutoMapper;
using Domain.Interfaces;
using Domain.Monetization.Model.Aggregates;
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
[ProducesResponseType(400)]
public class SubscriptionController(IRepositoryGeneric<Subscription> repositoryGeneric, IMapper mapper )  : ControllerBase
{
    private readonly IRepositoryGeneric<Subscription> _repositoryGeneric = repositoryGeneric;
    private readonly IMapper _mapper = mapper;
    
    // GET: api/v1/monetization/subscription/get-all
    /// <summary>
    /// Return all subscriptions
    /// </summary>
    /// <response code="200">Return all subscriptions</response>
    /// <response code="404">Not found</response>
    /// <response code="500">Internal Server Error</response>
    /// <response code="400">Bad Request</response>
    
    [HttpGet]
    [Route("get-all")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetAllSubscriptions()
    {
        var subscriptions = await _repositoryGeneric.GetAllAsync();
        var result = _mapper.Map<IEnumerable<Subscription>, IEnumerable<SubscriptionResponse>>(subscriptions);
        if (result == null) return NotFound();
        return Ok(result);
    }
    /// <summary>
    /// Return subscription by id
    /// </summary>
    /// <response code="200">Return subscription by id</response>
    /// <response code="404">Not found</response>
    /// <response code="500">Internal Server Error</response>
    /// <response code="400">Bad Request</response>


    [HttpGet]
    [Route("get-by-id/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetSubscriptionById(int id)
    {
       var subscription = await _repositoryGeneric.GetByIdAsync(id);
       var result = _mapper.Map<Subscription, SubscriptionResponse>(subscription);
       if(result == null) return NotFound();
       return Ok(result);
    }
    
    /// <summary>
    /// Update subscription
    /// </summary>
    /// <response code="200">Update subscription</response>
    /// <response code="500">Internal Server Error</response>
    /// <response code="404">If subscription to update Not found</response>
    /// <response code="400">Bad Request</response>
    
    [HttpPost]
    [Route("update")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateSubscription([FromBody] Subscription subscription)
    {
        var subscriptionToUpdate = await _repositoryGeneric.GetByIdAsync(subscription.Id);
        if (subscriptionToUpdate == null) return NotFound();
        await _repositoryGeneric.Update(subscriptionToUpdate);
        var subscriptionResponse = _mapper.Map<Subscription, SubscriptionResponse>(subscriptionToUpdate);
        return Ok(subscriptionResponse);
    }
    
    /// <summary>
    /// Delete subscription
    /// </summary>
    /// <response code="200">Delete subscription</response>
    /// <response code="404">If susbcription to delete Not found</response>
    /// <response code="500">Internal Server Error</response>
    /// <response code="400">Bad Request</response>

    [HttpGet]
    [Route("delete/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteSubscription(int id)
    {
        var subscriptionToDelete = await _repositoryGeneric.GetByIdAsync(id);
        if (subscriptionToDelete == null) return NotFound();
        await _repositoryGeneric.Delete(id);
        var subscriptionResponse = _mapper.Map<Subscription, SubscriptionResponse>(subscriptionToDelete);
        return StatusCode(201, subscriptionResponse);
    }
    
    /// <summary>
    /// Add subscription
    /// </summary>
    /// <response code="201">Add subscription</response>
    /// <response code="500">Internal Server Error</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized</response>

    [HttpPost]
    [Route("add-subscription")]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> CreateSubscription([FromBody] SubscriptionRequest subscriptionRequest)
    {
        var subscription = _mapper.Map<SubscriptionRequest, Subscription>(subscriptionRequest);
        await _repositoryGeneric.AddAsync(subscription);
        var subscriptionResponse = _mapper.Map<Subscription, SubscriptionResponse>(subscription);
        return Ok(subscriptionResponse);
    }
}