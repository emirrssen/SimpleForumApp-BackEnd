using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Application.Repositories.Auth
{
    public interface IEndPointPermissionRepository : IInjectable
    {
        Task<long> InsertAsync(EndPointPermission endPointPermission);
        Task UpdateAsync(EndPointPermission endPointPermission);
        Task<IList<EndPointPermission>> GetAllPermissionsByEndPointAsync(long endPointId);
    }
}
