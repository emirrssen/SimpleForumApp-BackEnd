using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForRoles.Commands.Insert
{
    public class Command : CommandBase
    {
        public long RoleId { get; set; }
        public long PermissionId { get; set; }
    }
}
