using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations.Core
{
    public class ExecutionOrderConfigurations : IEntityTypeConfiguration<ExecutionOrder>
    {
        public void Configure(EntityTypeBuilder<ExecutionOrder> builder)
        {
            builder
                .HasData(new List<ExecutionOrder>
                {
                    new() { Id = 1, Name = "Before Execution"},
                    new() { Id = 2, Name = "After Execution" }
                });
        }
    }
}
