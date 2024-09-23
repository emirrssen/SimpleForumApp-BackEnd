using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionManagement.Queries.GetById
{
    public class Query : QueryBase<Response>
    {
        public long Id { get; set; }
    }
}
