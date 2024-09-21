using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.RoleManagement.Queries.GetById
{
    public class Query : QueryBase<Response>
    {
        public long Id { get; set; }
    }
}
