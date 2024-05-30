using System.Net.Mime;
using Application.Monetization.Request;
using Application.Monetization.Response;
using AutoMapper;
using Domain.Interface;
using Domain.Monetization.Model.Aggregates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Monetization.REST.Controllers;

[Route("api/v1/monetization/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[AllowAnonymous]
public class SubscriptionController(IRepositoryGeneric<Subscription> repositoryGeneric, IMapper mapper )  : ControllerBase
{
    private readonly IRepositoryGeneric<Subscription> _repositoryGeneric = repositoryGeneric;
    private readonly IMapper _mapper = mapper;
    
    [HttpGet]
    [Route("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var subscriptions = await _repositoryGeneric.GetAllAsync();
        var result = _mapper.Map<IEnumerable<Subscription>, IEnumerable<SubscriptionResponse>>(subscriptions);
        if (result == null) return NotFound();
        return Ok(result);
    }


    [HttpGet]
    [Route("get-by-id/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
       var subscription = await _repositoryGeneric.GetByIdAsync(id);
       var result = _mapper.Map<Subscription, SubscriptionResponse>(subscription);
       if(result == null) return NotFound();
       return Ok(result);
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
    public async Task<IActionResult> Post([FromBody] SubscriptionRequest subscriptionRequest)
    {
        var subscription = _mapper.Map<SubscriptionRequest, Subscription>(subscriptionRequest);
        await _repositoryGeneric.Add(subscription);
        return Ok(true);
    }
}