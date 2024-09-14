using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.CountryManagement.Queries.GetCountries
{
    public class Query : QueryBase<IList<Response>>
    {
    }
}
