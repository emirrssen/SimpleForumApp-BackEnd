using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations.Auth
{
    public class PageClaimBusinessRuleConfigurations : IEntityTypeConfiguration<PageClaimBusinessRule>
    {
        public void Configure(EntityTypeBuilder<PageClaimBusinessRule> builder)
        {
            builder
                .HasKey(x => new { x.PageId, x.ClaimBusinessRuleId });

            builder
                .HasOne(x => x.Page)
                .WithMany(x => x.ClaimBusinessRules)
                .HasForeignKey(x => x.PageId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.ClaimBusinessRule)
                .WithMany(x => x.Pages)
                .HasForeignKey(x => x.ClaimBusinessRuleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Status)
                .WithMany(x => x.PageClaimBusinessRules)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
