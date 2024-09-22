using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.EndPointManagement.Commands.UpdateById
{
    public class Command : CommandBase
    {
        public long Id { get; set; }
        public bool IsUse { get; set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; }
    }
}
