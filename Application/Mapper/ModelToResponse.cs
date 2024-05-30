using Application.Monetization.Response;
using AutoMapper;
using Domain.Monetization.Model.Aggregates;
using Infraestructure.Monetization.Model.Aggregates;

namespace Application.Mapper;

public class ModelToResponse : Profile
{
    public ModelToResponse()
    {
        CreateMap<Subscription, SubscriptionResponse>();
        CreateMap<Commision, CommisionResponse>();
    }
}