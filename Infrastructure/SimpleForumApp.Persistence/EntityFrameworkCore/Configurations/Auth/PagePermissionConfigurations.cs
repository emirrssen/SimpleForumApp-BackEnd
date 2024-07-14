using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations.Auth
{
    public class PagePermissionConfigurations : IEntityTypeConfiguration<PagePermission>
    {
        public void Configure(EntityTypeBuilder<PagePermission> builder)
        {
            builder
                .HasKey(x => new { x.PageId, x.PermissionId });

            builder
                .HasOne(x => x.Permission)
                .WithMany(x => x.Pages)
                .HasForeignKey(x => x.PermissionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Page)
                .WithMany(x => x.Permissions)
                .HasForeignKey(x => x.PageId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Status)
                .WithMany(x => x.PagePermissions)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
