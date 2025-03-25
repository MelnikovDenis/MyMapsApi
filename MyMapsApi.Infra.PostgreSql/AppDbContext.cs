using Microsoft.EntityFrameworkCore;
using MyMapsApi.Core.Entities;
using MyMapsApi.Infra.PostgreSql.Configurations;

namespace MyMapsApi.Infra.PostgreSql;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Post> Posts {  get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new PostConfigration());
        builder.ApplyConfiguration(new UserConfiguration());
    }
}
