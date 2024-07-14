using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations.Auth
{
    public class ClaimBusinessRuleConfigurations : IEntityTypeConfiguration<ClaimBusinessRule>
    {
        public void Configure(EntityTypeBuilder<ClaimBusinessRule> builder)
        {
            builder
                .HasOne(x => x.ExecutionOrder)
                .WithMany(x => x.ClaimBusinessRules)
                .HasForeignKey(x => x.ExecutionOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Status)
                .WithMany(x => x.ClaimBusinessRules)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
