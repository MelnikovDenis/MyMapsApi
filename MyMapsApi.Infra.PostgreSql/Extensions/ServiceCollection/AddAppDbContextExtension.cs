using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace MyMapsApi.Infra.PostgreSql.Extensions.ServiceCollection;

public static class AddAppDbContextExtension
{
    public static void AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(configuration.GetConnectionString("DefaultConnection"));
        var dataSource = dataSourceBuilder.Build();
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(dataSource));
    }
}
