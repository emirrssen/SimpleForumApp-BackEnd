namespace SimpleForumApp.Application.CQRS.Admin.CountryManagement.Queries.GetCountries
{
    public record Response
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
