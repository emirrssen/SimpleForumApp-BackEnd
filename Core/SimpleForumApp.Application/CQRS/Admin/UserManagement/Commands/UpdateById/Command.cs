using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.Commands.UpdateById
{
    public class Command : CommandBase
    {
        public long Id { get; set; }
        public long StatusId { get; set; }
        public long GenderId { get; set; }
        public long CountryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
