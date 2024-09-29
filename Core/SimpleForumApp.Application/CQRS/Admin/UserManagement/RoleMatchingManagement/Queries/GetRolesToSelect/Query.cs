using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.RoleMatchingManagement.Queries.GetRolesToSelect
{
    public class Query : QueryBase<IList<Response>>
    {
        public long UserId { get; set; }
    }
}
