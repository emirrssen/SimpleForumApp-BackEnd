using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Home.Queries.GetAgenda
{
    public class Query : QueryBase<IList<Response>>
    {
    }
}
