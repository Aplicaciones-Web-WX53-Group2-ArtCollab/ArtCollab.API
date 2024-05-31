using Application.Request;
using AutoMapper;
using Infraestructure.Models;

namespace Application.Mapper;

public class RequestToModel : Profile
{
    public RequestToModel()
    {
        CreateMap<CommentRequest, Comment>();
    }
}