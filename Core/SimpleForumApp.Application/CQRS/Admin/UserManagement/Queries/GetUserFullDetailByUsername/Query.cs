using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.Queries.GetUserFullDetailByUsername
{
    public class Query : QueryBase<Response>
    {
        public string UserName { get; set; }
    }
}
