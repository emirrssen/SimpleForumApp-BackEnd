using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Application.Repositories.Auth
{
    public interface IRolePermissionRepository : IInjectable
    {
        Task<long> InsertAsync(RolePermission rolePermission);
        Task UpdateAsync(RolePermission rolePermission);
    }
}
