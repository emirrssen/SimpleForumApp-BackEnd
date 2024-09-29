using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.RoleMatchingManagement.Commands.BulkUpdate
{
    public class Command : CommandBase
    {
        public Dto[] ItemsToUpdate { get; set; }
    }

    public class Dto
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public long StatusId { get; set; }

    }
}
