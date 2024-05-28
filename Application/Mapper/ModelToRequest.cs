using Application.Users.Request;
using AutoMapper;
using Infrastructure.Model;
using Infrastructure.Users.Model;

namespace Application.Mapper;

public class ModelToRequest : Profile
{
    public ModelToRequest()
    {
        CreateMap<Reader, ReaderRequest>();
    }
}