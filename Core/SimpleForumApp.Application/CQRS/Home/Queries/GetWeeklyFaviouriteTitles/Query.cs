using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Home.Queries.GetWeeklyFaviouriteTitles
{
    public class Query : QueryBase<IList<Response>>
    {
    }
}
