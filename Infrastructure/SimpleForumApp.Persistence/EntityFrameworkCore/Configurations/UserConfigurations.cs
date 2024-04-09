using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForumApp.Domain.Entities;
using SimpleForumApp.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne(x => x.Person)
                .WithOne(y => y.User)
                .HasForeignKey<User>(x => x.PersonId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
