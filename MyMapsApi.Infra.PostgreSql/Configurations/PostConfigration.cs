using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMapsApi.Core.Entities;

namespace MyMapsApi.Infra.PostgreSql.Configurations;

internal class PostConfigration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User)
            .WithMany(x => x.Posts)
            .HasForeignKey(x => x.Name)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
