using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.DTOs.App.Author;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations.Dto.Author
{
    public class WeeklyFavouriteAuthorConfigurations : IEntityTypeConfiguration<WeeklyFavouriteAuthor>
    {
        public void Configure(EntityTypeBuilder<WeeklyFavouriteAuthor> builder)
        {
            builder
                .ToView("WeeklyFavouriteAuthors")
                .HasNoKey();
        }
    }
}
