using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations.App
{
    public class GenderConfigurations : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder
                .HasOne(x => x.Status)
                .WithMany(y => y.Genders)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasData(new List<Gender>
                {
                    new() { Id = 1, Name = "Erkek", StatusId = 1 },
                    new() { Id = 2, Name = "Kadın", StatusId = 1 },
                    new() { Id = 3, Name = "Belirsiz", StatusId = 1 },
                    new() { Id = 4, Name = "Belirtmek İstemiyorum", StatusId = 1 }
                });
        }
    }
}
