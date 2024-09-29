using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForEndPoints.Queries.GetUnmatchedPermissions
{
    public class Query : QueryBase<IList<Response>>
    {
        public long EndPointId { get; set; }
    }
}
