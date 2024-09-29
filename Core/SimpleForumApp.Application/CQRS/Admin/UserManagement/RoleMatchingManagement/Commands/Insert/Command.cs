using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.RoleMatchingManagement.Commands.Insert
{
    public class Command : CommandBase
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
    }
}
