using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Application.Repositories.Auth
{
    public interface IUserRoleRepository : IInjectable
    {
        Task<long> InsertAsync(UserRole userRole);
        Task UpdateAsync(UserRole userRole);
        Task<long[]> GetAllUserPermissionsByUserIdAsync(long userId);
    }
}
