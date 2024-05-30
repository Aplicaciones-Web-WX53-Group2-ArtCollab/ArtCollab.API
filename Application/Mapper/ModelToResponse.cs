using Application.Request;
using AutoMapper;
using Infraestructure.Models;

namespace Application.Mapper;

public class ModelToResponse : Profile
{
    public ModelToResponse()
    {
        CreateMap<Subscription, SubsciptionRequest>();
    }
}