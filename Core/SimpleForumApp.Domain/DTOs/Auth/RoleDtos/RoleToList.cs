using SimpleForumApp.Domain.Entities;

namespace SimpleForumApp.Domain.DTOs.Auth.RoleDtos
{
    public class RoleToList : EntityWithId
    {
        public string StatusName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
