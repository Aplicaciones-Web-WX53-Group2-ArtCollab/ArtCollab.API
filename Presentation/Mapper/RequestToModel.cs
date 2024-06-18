using AutoMapper;
using Infrastructure.Collaboration.Model;
using Infrastructure.Content.Models;
using Infrastructure.Monetization.Model.Aggregates;
using Infrastructure.Users.Model;
using Presentation.Collaboration.Request;
using Presentation.Content.Request;
using Presentation.Monetization.Request;
using Presentation.Users.Request;

namespace Presentation.Mapper;

public class RequestToModel : Profile
{
    public RequestToModel()
    {
        CreateMap<ReaderRequest, Reader>();
        CreateMap<CommisionRequest, Commision>();
        CreateMap<SubscriptionRequest, Subscription>();
        CreateMap<CommentRequest, Comment>();
        CreateMap<TemplateRequest, Template>();
    }
}