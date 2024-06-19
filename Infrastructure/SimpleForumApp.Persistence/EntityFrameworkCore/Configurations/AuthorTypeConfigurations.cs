using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities.App;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations
{
    public class AuthorTypeConfigurations : IEntityTypeConfiguration<AuthorType>
    {
        public void Configure(EntityTypeBuilder<AuthorType> builder)
        {
            builder
                .HasOne(x => x.Status)
                .WithMany(x => x.AuthorTypes)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasData(new List<AuthorType>
                {
                    new() { Id = 1, StatusId = 1, Name = "Kullanıcı" },
                    new() { Id = 2, StatusId = 1, Name = "Grup"}
                });
        }
    }
}
