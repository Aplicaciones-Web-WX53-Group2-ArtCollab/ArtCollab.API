using Application.Monetization.Request;
using AutoMapper;
using Domain.Monetization.Model.Aggregates;
using Infraestructure.Monetization.Model.Aggregates;

namespace Application.Mapper;

public class RequestToModel : Profile
{
    public RequestToModel()
    {
        CreateMap<SubscriptionRequest, Subscription>();
        CreateMap<CommisionRequest, Commision>();
    }
}