using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations
{
    public class ActionConfigurations : IEntityTypeConfiguration<Domain.Entities.App.Action>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.App.Action> builder)
        {
            builder
                .HasOne(x => x.Status)
                .WithMany(x => x.Actions)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasData(new List<Domain.Entities.App.Action>
                {
                    new() { Id = 1, Name = "Sevdi", StatusId = 1 },
                    new() { Id = 2, Name = "Sevmedi", StatusId = 1 }
                });
        }
    }
}
