using Application.Monetization.Request;
using AutoMapper;
using Domain.Monetization.Model.Aggregates;
using Infraestructure.Monetization.Model.Aggregates;

namespace Application.Mapper;

public class ModelToRequest : Profile
{
    public ModelToRequest()
    {
        CreateMap<Subscription, SubscriptionRequest>();
        CreateMap<Commision, CommisionRequest>();
    }
}