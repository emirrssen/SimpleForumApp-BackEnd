using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Domain.Entities.App;
using SimpleForumApp.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Context
{
    public class SimpleForumAppContext : IdentityDbContext<User, Role, long>
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public SimpleForumAppContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(SimpleForumAppContext)));
            base.OnModelCreating(modelBuilder);
        }
    }
}
