using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.DTOs.Auth.PermissionDtos
{
    public class PermissionDetails : Entity
    {
        public long StatusId { get; set; }
        public string StatusName { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
