using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Application.Repositories.App
{
    public interface IStatusRepository : IInjectable
    {
        Task<IList<Status>> GetAllAsync();
    }
}
