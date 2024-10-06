using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Home.Queries.GetTitles
{
    public class Query : QueryBase<IList<Response>>
    {
    }
}
