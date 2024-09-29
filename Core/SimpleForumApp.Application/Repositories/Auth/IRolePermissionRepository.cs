using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.DTOs.Auth.RolePermission;
using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Application.Repositories.Auth
{
    public interface IRolePermissionRepository : IInjectable
    {
        Task<long> InsertAsync(RolePermission rolePermission);
        Task UpdateAsync(RolePermission rolePermission);
        Task<IList<RolePermission>> GetByPermissionIdAsync(long permissionId);
        Task<IList<RolePermission>> GetByRoleIdAsync(long roleId);
        Task<IList<RolePermissionDetail>> GetDetailsByRoleIdAsync(long roleId);
        Task<RolePermission?> GetByRoleAndPermissionIdAsync(long roleId, long permissionId);
    }
}
