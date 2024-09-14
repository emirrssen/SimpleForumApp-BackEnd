using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.GenderManagement.Queries.GetGenders
{
    public class Query : QueryBase<IList<Response>>
    {
    }
}
