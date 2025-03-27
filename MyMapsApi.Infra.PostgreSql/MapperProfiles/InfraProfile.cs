using AutoMapper;
using MyMapsApi.App.Infra.Contracts.Dtos;
using MyMapsApi.Core.Entities;

namespace MyMapsApi.Infra.PostgreSql.MapperProfiles;

public class InfraProfile : Profile
{
    public InfraProfile()
    {
        CreateMap<InternalCreatePostDto, Post>()
            .ForMember(dst => dst.Id, src => src.MapFrom(_ => Guid.NewGuid()));

        CreateMap<InternalCreateUserDto, User>();
    }
}