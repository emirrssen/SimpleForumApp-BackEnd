using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.RoleManagement.Queries.GetAll
{
    public class Query : QueryBase<IList<Response>>
    {
        public long StatusId { get; set; }
    }
}
