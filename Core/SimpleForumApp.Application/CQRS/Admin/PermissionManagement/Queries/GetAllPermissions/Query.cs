using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionManagement.Queries.GetAllPermissions
{
    public class Query : QueryBase<IList<Response>>
    {
        public bool IsPassiveShown { get; set; }
    }
}
