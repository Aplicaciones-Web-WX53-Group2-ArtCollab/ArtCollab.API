using Application.Request;
using AutoMapper;
using Infrastructure.Model;

namespace Application.Mapper;

public class ModelToRequest : Profile
{
    public ModelToRequest()
    {
        CreateMap<Reader, ReaderRequest>();
    }
}