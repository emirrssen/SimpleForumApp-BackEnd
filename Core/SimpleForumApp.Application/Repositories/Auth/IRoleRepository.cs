using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Application.Repositories.Auth
{
    public interface IRoleRepository : IInjectable
    {
        Task<long> InsertAsync(Role role);
        Task UpdateAsync(Role role);
    }
}
