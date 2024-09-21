namespace SimpleForumApp.Application.CQRS.Admin.PersonManagement.Queries.GetAllPersonDetails
{
    public class Response
    {
        public long Id { get; set; }
        public long GenderId { get; set; }
        public long CountryId { get; set; }
        public string GenderName { get; set; }
        public string CountryName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ProfileImage { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
