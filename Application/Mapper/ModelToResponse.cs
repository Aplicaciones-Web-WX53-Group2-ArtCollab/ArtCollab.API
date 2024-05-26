using Application.Response;
using AutoMapper;
using Infrastructure.Model;

namespace Application.Mapper;

public class ModelToResponse : Profile
{
    public ModelToResponse()
    {
        CreateMap<Reader, ReaderResponse>();
    }
}