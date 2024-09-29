using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.DTOs.Auth.UserRole;
using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Application.Repositories.Auth
{
    public interface IUserRoleRepository : IInjectable
    {
        Task<long> InsertAsync(UserRole userRole);
        Task UpdateAsync(UserRole userRole);
        Task<long[]> GetAllUserPermissionsByUserIdAsync(long userId);
        Task<IList<UserRole>> GetByUserIdAsync(long userId);
        Task<IList<UserRoleDetail>> GetDetailsByUserIdAsync(long userId);
        Task<UserRole?> GetByUserIdAndRoleIdAsync(long userId, long roleId);
    }
}
