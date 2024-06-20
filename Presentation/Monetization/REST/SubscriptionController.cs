using System.Net.Mime;
using AutoMapper;
using Domain.Monetization.Model.Aggregates;
using Domain.Monetization.Model.Commands;
using Domain.Monetization.Model.Queries;
using Domain.Monetization.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Monetization.REST.Resources;
using Presentation.Monetization.REST.Transform;

namespace Presentation.Monetization.REST;



[Route("api/v1/monetization/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[AllowAnonymous]
[ProducesResponseType(500)]
[ProducesResponseType(400)]
[ProducesResponseType(401)]
[ProducesResponseType(403)]
public class SubscriptionController(ISubscriptionQueryService subscriptionQueryService, ISubscriptionCommandService subscriptionCommandService )  : ControllerBase
{
    
    // GET: api/v1/monetization/subscription/get-all
    /// <summary>
    /// Return all subscriptions
    /// </summary>
    /// <response code="200">Return all subscriptions</response>
    /// <response code="404">Not found</response>
    /// <response code="500">Internal Server Error</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="403">Forbidden</response>
    
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetAllSubscriptions()
    {
        var query = new GetAllSubscriptionsQuery();
        var subscriptions = await subscriptionQueryService.Handle(query);
        var subscriptionResource = subscriptions.Select(SubscriptionResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(subscriptionResource);

    }
    /// <summary>
    /// Return subscription by id
    /// </summary>
    /// <response code="200">Return subscription by id</response>
    /// <response code="404">Not found</response>
    /// <response code="500">Internal Server Error</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="403">Forbidden</response>


    [HttpGet("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetSubscriptionById(int id)
    {
        var query = new GetSubscriptionByIdQuery(id);
        var subscription = await subscriptionQueryService.Handle(query);
        if (subscription == null) return NotFound();
        var subscriptionResource = SubscriptionResourceFromEntityAssembler.ToResourceFromEntity(subscription);
        return Ok(subscriptionResource);
    }
    
    /// <summary>
    /// Update subscription
    /// </summary>
    /// <response code="200">Update subscription</response>
    /// <response code="500">Internal Server Error</response>
    /// <response code="404">If subscription to update Not found</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="403">Forbidden</response>
    
    [HttpPut("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateSubscription(int id,[FromBody] UpdateSubscriptionResource updateSubscriptionResource)
    {
        var command = UpdateSubscriptionCommandFromResourceAssembler.ToCommandFromResource(id, updateSubscriptionResource);
        var subscription = await subscriptionCommandService.Handle(command);
        var subscriptionResource = SubscriptionResourceFromEntityAssembler.ToResourceFromEntity(subscription);
        return Ok(subscriptionResource);
    }
    
    /// <summary>
    /// Delete subscription
    /// </summary>
    /// <response code="200">Delete subscription</response>
    /// <response code="404">If susbcription to delete Not found</response>
    /// <response code="500">Internal Server Error</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="403">Forbidden</response>

    [HttpDelete("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteSubscription(int id)
    {
        var command = new DeleteSubscriptionCommand(id);
        var subscription = await subscriptionCommandService.Handle(command);
        var subscriptionResource = SubscriptionResourceFromEntityAssembler.ToResourceFromEntity(subscription);
        return Ok(subscriptionResource);
    }
    
    /// <summary>
    /// Add subscription
    /// </summary>
    /// <response code="201">Add subscription</response>
    /// <response code="500">Internal Server Error</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="403">Forbidden</response>

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> CreateSubscription([FromBody] CreateSubscriptionResource createSubscriptionResource)
    {
        var command = CreateSubscriptionCommandFromResourceAssembler.ToCommandFromResource(createSubscriptionResource);
        var subscription = await subscriptionCommandService.Handle(command);
        var subscriptionResource = SubscriptionResourceFromEntityAssembler.ToResourceFromEntity(subscription);
        return StatusCode(201, subscriptionResource);
    }
}