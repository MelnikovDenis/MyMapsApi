using AutoMapper;
using MyMapsApi.App.Contracts.Dtos;
using MyMapsApi.App.Infra.Contracts.Dtos;
using MyMapsApi.Core.Entities;
using MyMapsApi.Shared;

namespace MyMapsApi.App.Implements.MapperProfile;

public class AppProfile : Profile
{
    public AppProfile()
    {
        CreateMap<LoginOrRegisterDto, InternalCreateUserDto>()
            .ForMember(dst => dst.PasswordHash, src => src.MapFrom(x => HashHelper.CreateHash(x.Password)));

        CreateMap<Post, PostInfoDto>();
    }
}
