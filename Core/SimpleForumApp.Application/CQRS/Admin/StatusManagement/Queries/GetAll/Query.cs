using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.StatusManagement.Queries.GetAll
{
    public class Query : QueryBase<IList<Response>>
    {
    }
}
