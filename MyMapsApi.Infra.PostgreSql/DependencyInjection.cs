using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyMapsApi.App.Infra.Contracts;
using MyMapsApi.Infra.PostgreSql.Extensions.ServiceCollection;
using MyMapsApi.Infra.PostgreSql.MapperProfiles;
using MyMapsApi.Infra.PostgreSql.Repos;

namespace MyMapsApi.Infra.PostgreSql;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraLayer(this IServiceCollection services, IConfiguration config)
    {
        services.AddAutoMapper(typeof(InfraProfile));

        services.AddAppDbContext(config);

        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IPostRepository, PostRepository>();

        return services;
    }
}
