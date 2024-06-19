using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities.App;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations
{
    public class TitleActionConfigurations : IEntityTypeConfiguration<TitleAction>
    {
        public void Configure(EntityTypeBuilder<TitleAction> builder)
        {
            builder
                .HasKey(x => new { x.ActionId, x.TitleId, x.UserId });

            builder
                .HasOne(x => x.Status)
                .WithMany(x => x.TitleActions)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.TitleActions)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Action)
                .WithMany(x => x.Titles)
                .HasForeignKey(x => x.ActionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Title)
                .WithMany(x => x.Actions)
                .HasForeignKey(x => x.TitleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
