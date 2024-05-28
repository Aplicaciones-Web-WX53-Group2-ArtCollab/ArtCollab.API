using Application.Users.Response;
using AutoMapper;
using Infrastructure.Model;
using Infrastructure.Users.Model;

namespace Application.Mapper;

public class ModelToResponse : Profile
{
    public ModelToResponse()
    {
        CreateMap<Reader, ReaderResponse>();
    }
}