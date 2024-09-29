using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForEndPoints.Commands.Insert
{
    public class Command : CommandBase
    {
        public long EndPointId { get; set; }
        public long PermissionId { get; set; }
    }
}
