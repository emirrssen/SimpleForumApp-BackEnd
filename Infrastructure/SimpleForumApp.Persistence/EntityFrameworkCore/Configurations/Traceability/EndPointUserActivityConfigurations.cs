using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities.Traceability;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations.Traceability
{
    public class EndPointUserActivityConfigurations : IEntityTypeConfiguration<EndPointUserActivity>
    {
        public void Configure(EntityTypeBuilder<EndPointUserActivity> builder)
        {
            builder.HasKey(x => x.EndPointActivityId);

            builder
                .HasOne(x => x.EndPointActivity)
                .WithOne(x => x.EndPointUserActivity)
                .HasForeignKey<EndPointUserActivity>(x => x.EndPointActivityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.EndPointUserActivities)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
