using AutoMapper;
using Infrastructure.Collaboration.Model;
using Infrastructure.Monetization.Model.Aggregates;
using Infrastructure.Users.Model;
using Presentation.Collaboration.Request;
using Presentation.Monetization.Request;
using Presentation.Users.Request;

namespace Presentation.Mapper;

public class ModelToRequest : Profile
{
    public ModelToRequest()
    {
        CreateMap<Reader, ReaderRequest>();
        CreateMap<Comment, CommentRequest>();
        CreateMap<Subscription, SubscriptionRequest>();
        CreateMap<Commision, CommisionRequest>();
        
    }
}