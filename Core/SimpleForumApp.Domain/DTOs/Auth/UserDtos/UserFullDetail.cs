using SimpleForumApp.Domain.Entities;

namespace SimpleForumApp.Domain.DTOs.Auth.UserDtos
{
    public class UserFullDetail : Entity
    {
        public long PersonId { get; set; }
        public long StatusId { get; set; }
        public long GenderId { get; set; }
        public long CountryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string CountryName { get; set; }
        public string GenderName { get; set; }
    }
}
