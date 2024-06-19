using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities.App;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations
{
    public class AuthorConfigurations : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder
                .HasOne(x => x.Status)
                .WithMany(x => x.Authors)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Authors)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Group)
                .WithMany(x => x.Authors)
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.AuthorType)
                .WithMany(x => x.Authors)
                .HasForeignKey(x => x.AuthorTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasCheckConstraint(
                    @"CK_Author_UserId_GroupId", "([UserId] IS NOT NULL AND [GroupId] IS NULL) OR " +
                    "([UserId] IS NULL AND [GroupId] IS NOT NULL)"
                );
        }
    }
}
