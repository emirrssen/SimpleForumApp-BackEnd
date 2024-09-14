using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.Entities.App;

namespace SimpleForumApp.Application.Repositories.App
{
    public interface IGenderRepository : IInjectable
    {
        Task<IList<Gender>> GetAllAsync();
    }
}
