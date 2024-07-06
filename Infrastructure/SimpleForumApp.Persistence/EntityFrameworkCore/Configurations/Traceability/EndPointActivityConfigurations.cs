using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities.Traceability;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations.Traceability
{
    public class EndPointActivityConfigurations : IEntityTypeConfiguration<EndPointActivity>
    {
        public void Configure(EntityTypeBuilder<EndPointActivity> builder)
        {
            builder
                .HasOne(x => x.EndPoint)
                .WithMany(x => x.EndPointActivities)
                .HasForeignKey(x => x.EndPointId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.
                Property(x => x.ActivityStartDate)
                .HasColumnType("datetime2");

            builder
                .Property(x => x.ActivityEndDate)
                .HasColumnType("datetime2");
        }
    }
}
