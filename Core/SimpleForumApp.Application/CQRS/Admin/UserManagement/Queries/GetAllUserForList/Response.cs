namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.Queries.GetAllUserForList
{
    public class Response
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GenderName { get; set; }
        public string CountryName { get; set; }
        public string DateOfBirth { get; set; }
        public string StatusName { get; set; }
    }
}
