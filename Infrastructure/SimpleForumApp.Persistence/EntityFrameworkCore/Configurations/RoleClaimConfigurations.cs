using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations
{
    public class RoleClaimConfigurations : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.HasKey(x => new { x.RoleId, x.ClaimId });

            builder
                .HasOne(x => x.Role)
                .WithMany(y => y.Claims)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Claim)
                .WithMany(y => y.Roles)
                .HasForeignKey(x => x.ClaimId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Status)
                .WithMany(y => y.RoleClaims)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
