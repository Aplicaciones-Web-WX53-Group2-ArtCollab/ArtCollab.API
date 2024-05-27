using Application.Request;
using AutoMapper;
using Infraestructure.Models;

namespace Application.Mapper;

public class ModelToRequest : Profile
{
    public ModelToRequest()
    {
        CreateMap<Comment, CommentRequest>();
    }
}