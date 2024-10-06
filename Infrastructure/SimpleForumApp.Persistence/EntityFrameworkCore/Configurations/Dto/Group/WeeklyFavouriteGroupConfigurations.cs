using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.DTOs.App.Group;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations.Dto.Group
{
    public class WeeklyFavouriteGroupConfigurations : IEntityTypeConfiguration<WeeklyFavouriteGroup>
    {
        public void Configure(EntityTypeBuilder<WeeklyFavouriteGroup> builder)
        {
            builder
                .ToView("WeeklyFavouriteGroups")
                .HasNoKey();
        }
    }
}
