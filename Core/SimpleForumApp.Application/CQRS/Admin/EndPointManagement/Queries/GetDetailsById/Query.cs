using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.EndPointManagement.Queries.GetDetailsById
{
    public class Query : QueryBase<Response>
    {
        public long Id { get; set; }
    }
}
