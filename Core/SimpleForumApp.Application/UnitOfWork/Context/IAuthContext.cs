using SimpleForumApp.Application.Repositories.Auth;
using SimpleForumApp.Application.UnitOfWork.Core;

namespace SimpleForumApp.Application.UnitOfWork.Context
{
    public interface IAuthContext : IInjectable
    {
        public IRoleRepository RoleRepository { get; }
        public IPermissionRepository PermissionRepository { get; }
        public IRolePermissionRepository RolePermissionRepository { get; }
        public IUserRoleRepository UserRoleRepository { get; }
        public IEndPointPermissionRepository EndPointPermissionRepository { get; }
    }
}
