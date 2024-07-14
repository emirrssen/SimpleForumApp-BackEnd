using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations.Core
{
    public class ActionTypeConfigurations : IEntityTypeConfiguration<ActionType>
    {
        public void Configure(EntityTypeBuilder<ActionType> builder)
        {
            builder
                .HasData(new List<ActionType>()
                {
                    new() { Id = 1, Name = "GET" },
                    new() { Id = 2, Name = "POST" },
                    new() { Id = 3, Name = "PUT" },
                    new() { Id = 4, Name = "DELETE" }
                });
        }
    }
}
