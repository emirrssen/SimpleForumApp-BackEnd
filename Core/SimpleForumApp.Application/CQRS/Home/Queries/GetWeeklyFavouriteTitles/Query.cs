using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Home.Queries.GetWeeklyFavouriteTitles
{
    public class Query : QueryBase<IList<Response>>
    {
    }
}
