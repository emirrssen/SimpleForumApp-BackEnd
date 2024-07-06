using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.DTOs.Auth.PermissionDtos;
using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Application.Repositories.Auth
{
    public interface IPermissionRepository : IInjectable
    {
        Task<long> InsertAsync(Permission permission);
        Task UpdateAsync(Permission permission);
        Task<IList<PermissionDetails>> GetAllDetailsAsync();
    }
}
