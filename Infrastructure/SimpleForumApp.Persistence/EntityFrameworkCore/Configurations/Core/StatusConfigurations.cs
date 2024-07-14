using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations.Core
{
    public class StatusConfigurations : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder
                .HasData(new List<Status>
                {
                    new() { Id = 1, Name = "Aktif", CreatedDate = new DateTime(2024, 4, 9) },
                    new() { Id = 2, Name = "Pasif", CreatedDate = new DateTime(2024, 4, 9) },
                    new() { Id = 3, Name = "Silindi", CreatedDate = new DateTime(2024, 4, 9) },
                });
        }
    }
}
