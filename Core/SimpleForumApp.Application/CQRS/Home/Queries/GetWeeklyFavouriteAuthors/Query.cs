using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Home.Queries.GetWeeklyFavouriteAuthors
{
    public class Query : QueryBase<IList<Response>>
    {
    }
}
