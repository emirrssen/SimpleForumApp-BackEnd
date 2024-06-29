using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Domain.Entities.App;
using SimpleForumApp.Domain.Entities.Auth;
using System.Reflection;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Context
{
    public class SimpleForumAppContext : IdentityDbContext<User, Role, long>
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Domain.Entities.App.Action> Actions { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorType> AuthorTypes { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<EntryAction> EntryActions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<TitleAction> TitleActions { get; set; }

        public SimpleForumAppContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(SimpleForumAppContext)));
            base.OnModelCreating(modelBuilder);
        }
    }
}
