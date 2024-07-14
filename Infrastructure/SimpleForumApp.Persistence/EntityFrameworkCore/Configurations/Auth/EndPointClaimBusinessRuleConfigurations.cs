using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations.Auth
{
    public class EndPointClaimBusinessRuleConfigurations : IEntityTypeConfiguration<EndPointClaimBusinessRule>
    {
        public void Configure(EntityTypeBuilder<EndPointClaimBusinessRule> builder)
        {
            builder
                .HasKey(x => new { x.EndPointId, x.ClaimBusinessRuleId });

            builder
                .HasOne(x => x.ClaimBusinessRule)
                .WithMany(x => x.EndPoints)
                .HasForeignKey(x => x.ClaimBusinessRuleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.EndPoint)
                .WithMany(x => x.ClaimBusinessRules)
                .HasForeignKey(x => x.EndPointId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Status)
                .WithMany(x => x.EndPointClaimBusinessRules)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
