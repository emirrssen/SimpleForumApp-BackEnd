using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.Entities.App
{
    public class Status : Entity
    {
        public string Name { get; set; }

        public ICollection<Gender> Genders { get; set; }
        public ICollection<Country> Countries { get; set; }
        public ICollection<Person> Persons { get; set; }
        public ICollection<Action> Actions { get; set; }
        public ICollection<AuthorType> AuthorTypes { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<GroupMember> GroupMembers { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Title> Titles { get; set; }
        public ICollection<Entry> Entries { get; set; }
        public ICollection<TitleAction> TitleActions { get; set; }
        public ICollection<EntryAction> EntryActions { get; set; }
        public ICollection<Permission> Permissions { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<EndPointPermission> EndPointPermissions { get; set; }
    }
}
