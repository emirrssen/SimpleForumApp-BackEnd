using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.Entities.App
{
    public class Person : Entity
    {
        public long StatusId { get; set; }
        public long GenderId { get; set; }
        public long CountryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ProfileImage { get; set; }

        public Status Status { get; set; }
        public Gender Gender { get; set; }
        public Country Country { get; set; }
        public User User { get; set; }
    }
}
