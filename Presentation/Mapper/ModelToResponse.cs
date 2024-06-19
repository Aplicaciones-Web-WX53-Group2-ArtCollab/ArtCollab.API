using AutoMapper;
using Domain.Content.Models.Aggregate;
using Domain.Content.Models.Response;
using Infrastructure.Collaboration.Model;
using Infrastructure.Monetization.Model.Aggregates;
using Infrastructure.Users.Model;
using Presentation.Collaboration.Response;
using Presentation.Monetization.Response;
using Presentation.Users.Response;

namespace Presentation.Mapper;

public class ModelToResponse : Profile
{
    public ModelToResponse()
    {
        CreateMap<Reader, ReaderResponse>();
        CreateMap<Comment, CommentResponse>();
        CreateMap<Subscription, SubscriptionResponse>();
        CreateMap<Commision, CommisionResponse>();
        CreateMap<Template, TemplateResponse>();
        
    }
}