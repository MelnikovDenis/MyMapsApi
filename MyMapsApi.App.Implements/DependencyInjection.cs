using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyMapsApi.App.Contracts;
using MyMapsApi.App.Implements.MapperProfile;
using MyMapsApi.App.Implements.TokenService;
using MyMapsApi.App.Implements.TokenService.Options;

namespace MyMapsApi.App.Implements;

public static class DependencyInjection
{
    public static IServiceCollection AddAppLayer(this IServiceCollection services, IConfiguration config)
    {
        services.AddAutoMapper(typeof(AppProfile));

        services.Configure<JwtTokenServiceOptions>(config.GetSection(nameof(JwtTokenServiceOptions)));
        services.AddTransient<JwtTokenService>();

        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IPostService, PostService>();

        return services;
    }
}
