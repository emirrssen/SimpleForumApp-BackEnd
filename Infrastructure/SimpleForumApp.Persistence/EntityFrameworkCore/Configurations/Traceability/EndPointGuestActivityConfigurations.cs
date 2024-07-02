using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities.Traceability;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations.Traceability
{
    public class EndPointGuestActivityConfigurations : IEntityTypeConfiguration<EndPointGuestActivity>
    {
        public void Configure(EntityTypeBuilder<EndPointGuestActivity> builder)
        {
            builder.HasKey(x => x.EndPointActivityId);

            builder
                .HasOne(x => x.EndPointActivity)
                .WithOne(x => x.EndPointGuestActivity)
                .HasForeignKey<EndPointGuestActivity>(x => x.EndPointActivityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Guest)
                .WithMany(x => x.EndPointGuestActivities)
                .HasForeignKey(x => x.GuestId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
