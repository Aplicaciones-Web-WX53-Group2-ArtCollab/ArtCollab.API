using Application.Request;
using AutoMapper;
using Infrastructure.Model;

namespace Application.Mapper;

public class RequestToModel : Profile
{
    public RequestToModel()
    {
        CreateMap<ReaderRequest, Reader>();
    }
}