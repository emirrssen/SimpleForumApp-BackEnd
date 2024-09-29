using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionManagement.Commands.UpdateById
{
    public class Command : CommandBase
    {
        public long Id { get; set; }
        public long StatusId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
