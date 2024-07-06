using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations.Auth
{
    public class RoleConfigurations : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .HasOne(x => x.Status)
                .WithMany(x => x.Roles)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasIndex(x => x.Name)
                .IsUnique();
        }
    }
}
