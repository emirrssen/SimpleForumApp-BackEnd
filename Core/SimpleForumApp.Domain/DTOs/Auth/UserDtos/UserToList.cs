using SimpleForumApp.Domain.Entities;

namespace SimpleForumApp.Domain.DTOs.Auth.UserDtos
{
    public class UserToList : EntityWithId
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string GenderName { get; set; }
        public string CountryName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
