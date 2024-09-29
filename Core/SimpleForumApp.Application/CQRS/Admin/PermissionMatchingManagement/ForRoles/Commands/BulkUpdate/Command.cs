using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForRoles.Commands.BulkUpdate
{
    public class Command : CommandBase
    {
        public Dto[] ItemsToUpdate { get; set; }
    }

    public class Dto
    {
        public long RoleId { get; set; }
        public long PermissionId { get; set; }
        public long StatusId { get; set; }

    }
}
