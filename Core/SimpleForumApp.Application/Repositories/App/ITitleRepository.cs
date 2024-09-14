using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.Entities.App;

namespace SimpleForumApp.Application.Repositories.App
{
    public interface ITitleRepository : IInjectable
    {
        Task<long> InsertAsync(Title title);
    }
}

