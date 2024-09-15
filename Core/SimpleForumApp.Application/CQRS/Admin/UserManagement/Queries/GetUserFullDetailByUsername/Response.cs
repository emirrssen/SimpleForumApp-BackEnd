namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.Queries.GetUserFullDetailByUsername
{
    public class Response
    {
        public long StatusId { get; set; }
        public long GenderId { get; set; }
        public long CountryId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
