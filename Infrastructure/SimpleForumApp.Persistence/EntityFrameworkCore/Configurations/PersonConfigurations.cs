using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations
{
    public class PersonConfigurations : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .HasOne(x => x.Status)
                .WithMany(y => y.Persons)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Gender)
                .WithMany(y => y.Persons)
                .HasForeignKey(x => x.GenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Country)
                .WithMany(y => y.Persons)
                .HasForeignKey(x => x.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
