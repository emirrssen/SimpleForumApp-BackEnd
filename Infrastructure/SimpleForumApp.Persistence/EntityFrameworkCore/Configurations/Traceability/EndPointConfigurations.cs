using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Application.Enums;
using SimpleForumApp.Domain.Entities.Traceability;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations.Traceability
{
    public class EndPointConfigurations : IEntityTypeConfiguration<EndPoint>
    {
        public void Configure(EntityTypeBuilder<EndPoint> builder)
        {
            builder
                .HasOne(x => x.ActionType)
                .WithMany(x => x.EndPoints)
                .HasForeignKey(x => x.ActionTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
