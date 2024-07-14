using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Domain.Entities.App;
using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Domain.Entities.Core;
using SimpleForumApp.Domain.Entities.Traceability;
using System.Reflection;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Context
{
    public class SimpleForumAppContext : IdentityDbContext<User, AspIdentityRole, long>
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
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<ActionType> ActionTypes { get; set; }
        public DbSet<EndPoint> EndPoints { get; set; }
        public DbSet<EndPointPermission> EndPointPermissions { get; set; }
        public DbSet<EndPointActivity> EndPointActivities { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PagePermission> PagePermissions { get; set; }
        public DbSet<ClaimBusinessRule> ClaimBusinessRules { get; set; }
        public DbSet<ExecutionOrder> ExecutionOrders { get; set; }
        public DbSet<PageClaimBusinessRule> PageClaimBusinessRules { get; set; }
        public DbSet<EndPointClaimBusinessRule> EndPointClaimBusinessRules { get; set; }

        public SimpleForumAppContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(SimpleForumAppContext)));
            base.OnModelCreating(modelBuilder);
        }

        public SimpleForumAppContext() { }
    }
}
