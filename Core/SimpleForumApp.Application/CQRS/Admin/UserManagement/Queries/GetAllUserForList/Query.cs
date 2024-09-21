using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.Queries.GetAllUserForList
{
    public class Query : QueryBase<IList<Response>>
    {
        public bool IsPassiveShown { get; set; }
    }
}
