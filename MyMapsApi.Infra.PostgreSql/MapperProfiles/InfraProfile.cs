using AutoMapper;
using MyMapsApi.Core.Entities;
using MyMapsApi.Infra.Contracts.Dtos;

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