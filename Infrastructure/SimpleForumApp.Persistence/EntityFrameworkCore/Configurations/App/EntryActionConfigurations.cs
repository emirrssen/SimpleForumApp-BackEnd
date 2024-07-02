using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities.App;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations.App
{
    public class EntryActionConfigurations : IEntityTypeConfiguration<EntryAction>
    {
        public void Configure(EntityTypeBuilder<EntryAction> builder)
        {
            builder
                .HasKey(x => new { x.ActionId, x.EntryId, x.UserId });

            builder
                .HasOne(x => x.Status)
                .WithMany(x => x.EntryActions)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.EntryActions)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Entry)
                .WithMany(x => x.Actions)
                .HasForeignKey(x => x.EntryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Action)
                .WithMany(x => x.Entries)
                .HasForeignKey(x => x.ActionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
