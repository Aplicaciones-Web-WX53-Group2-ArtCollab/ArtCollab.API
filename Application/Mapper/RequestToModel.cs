using Application.Users.Request;
using AutoMapper;
using Infrastructure.Model;
using Infrastructure.Users.Model;

namespace Application.Mapper;

public class RequestToModel : Profile
{
    public RequestToModel()
    {
        CreateMap<ReaderRequest, Reader>();
    }
}