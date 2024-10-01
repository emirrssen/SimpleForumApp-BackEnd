using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.Entities.App;

namespace SimpleForumApp.Application.Repositories.App
{
    public interface IEntryRepository : IInjectable
    {
        Task<long> InsertAsync(Entry entry);
    }
}
