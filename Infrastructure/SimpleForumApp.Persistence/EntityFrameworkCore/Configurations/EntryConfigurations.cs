using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities.App;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations
{
    public class EntryConfigurations : IEntityTypeConfiguration<Entry>
    {
        public void Configure(EntityTypeBuilder<Entry> builder)
        {
            builder
                .HasOne(x => x.Status)
                .WithMany(x => x.Entries)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Title)
                .WithMany(x => x.Entries)
                .HasForeignKey(x => x.TitleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Author)
                .WithMany(x => x.Entries)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
