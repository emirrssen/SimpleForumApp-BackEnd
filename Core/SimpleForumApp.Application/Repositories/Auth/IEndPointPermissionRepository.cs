using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.DTOs.Auth.EndPointPermission;
using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Application.Repositories.Auth
{
    public interface IEndPointPermissionRepository : IInjectable
    {
        Task<long> InsertAsync(EndPointPermission endPointPermission);
        Task UpdateAsync(EndPointPermission endPointPermission);
        Task<IList<EndPointPermission>> GetAllPermissionsByEndPointAsync(long endPointId);
        Task<IList<EndPointPermissionDetail>> GetAllPermissionDetailsByEndPointAsync(long endpointId);
        Task<IList<EndPointPermission>> GetByPermissionIdAsync(long permissionId);
        Task BulkUpdateAsync(EndPointPermission[] endPointPermissions);
        Task<EndPointPermission?> GetByEndPointAndPermissionIdAsync(long endpointId, long permissionId);
    }
}
