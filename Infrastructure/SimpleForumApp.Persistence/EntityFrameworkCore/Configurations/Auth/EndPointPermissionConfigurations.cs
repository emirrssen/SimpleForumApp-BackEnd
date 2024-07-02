using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations.Auth
{
    public class EndPointPermissionConfigurations : IEntityTypeConfiguration<EndPointPermission>
    {
        public void Configure(EntityTypeBuilder<EndPointPermission> builder)
        {
            builder
                .HasKey(x => new { x.EndPointId, x.PermissionId });

            builder
                .HasOne(x => x.Permission)
                .WithMany(x => x.EndPoints)
                .HasForeignKey(x => x.PermissionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.EndPoint)
                .WithMany(x => x.Permissions)
                .HasForeignKey(x => x.EndPointId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Status)
                .WithMany(x => x.EndPointPermissions)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
