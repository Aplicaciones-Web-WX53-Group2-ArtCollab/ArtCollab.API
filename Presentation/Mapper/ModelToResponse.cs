using AutoMapper;
using Infrastructure.Collaboration.Model;
using Infrastructure.Content.Models;
using Infrastructure.Monetization.Model.Aggregates;
using Infrastructure.Users.Model;
using Presentation.Collaboration.Response;
using Presentation.Content.Response;
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