using Application.Response;
using AutoMapper;
using Infraestructure.Models;

namespace Application.Mapper;

public class ModelToResponse : Profile
{
    public ModelToResponse()
    {
        CreateMap<Template, TemplateResponse>();
    }
}