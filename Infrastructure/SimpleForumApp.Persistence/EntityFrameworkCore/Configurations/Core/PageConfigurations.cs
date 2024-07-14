using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations.Core
{
    public class PageConfigurations : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder
                .HasOne(x => x.Status)
                .WithMany(x => x.Pages)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
