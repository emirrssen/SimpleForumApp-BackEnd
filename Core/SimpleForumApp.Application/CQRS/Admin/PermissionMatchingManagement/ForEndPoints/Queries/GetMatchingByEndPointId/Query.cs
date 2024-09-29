using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForEndPoints.Queries.GetMatchingByEndPointId
{
    public class Query : QueryBase<IList<Response>>
    {
        public long EndPointId { get; set; }
    }
}
