using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.EndPointManagement.Queries.GetAllByStatus
{
    public class Query : QueryBase<IList<Response>>
    {
        public bool IsActive { get; set; }
    }
}
