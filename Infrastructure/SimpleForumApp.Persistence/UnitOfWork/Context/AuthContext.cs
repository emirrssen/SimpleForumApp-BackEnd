using SimpleForumApp.Application.Repositories.Auth;
using SimpleForumApp.Application.UnitOfWork.Context;
using SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.Auth;
using SimpleForumApp.Persistence.UnitOfWork.Core;

namespace SimpleForumApp.Persistence.UnitOfWork.Context
{
    public class AuthContext : ServiceGetter, IAuthContext
    {
        public AuthContext(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public IRoleRepository RoleRepository => GetService<IRoleRepository>();
        public IPermissionRepository PermissionRepository => GetService<IPermissionRepository>();
        public IRolePermissionRepository RolePermissionRepository => GetService<IRolePermissionRepository>();
        public IUserRoleRepository UserRoleRepository => GetService<IUserRoleRepository>();
        public IEndPointPermissionRepository EndPointPermissionRepository => GetService<IEndPointPermissionRepository>();
        public IClaimBusinessRuleRepository ClaimBusinessRuleRepository => GetService<IClaimBusinessRuleRepository>();
        public IEndPointClaimBusinessRuleRepository EndPointClaimBusinessRuleRepository => GetService<IEndPointClaimBusinessRuleRepository>();
    }
}
