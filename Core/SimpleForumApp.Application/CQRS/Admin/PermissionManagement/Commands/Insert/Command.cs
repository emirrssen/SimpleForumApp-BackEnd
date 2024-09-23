using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionManagement.Commands.Insert
{
    public class Command : CommandBase
    {
        public long StatusId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
