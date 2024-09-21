using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.DTOs.Auth.RoleDtos;
using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Application.Repositories.Auth
{
    public interface IRoleRepository : IInjectable
    {
        Task<long> InsertAsync(Role role);
        Task UpdateAsync(Role role);
        Task<IList<RoleToList>> GetAllDetailsByStatusAsync(long statusId);
        Task<IList<Role>> GetAllAsync();
    }
}
