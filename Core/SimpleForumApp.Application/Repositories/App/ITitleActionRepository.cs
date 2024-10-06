using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.Entities.App;

namespace SimpleForumApp.Application.Repositories.App
{
    public interface ITitleActionRepository : IInjectable
    {
        Task<IList<TitleAction>> GetByTitleIdAndUserIdAsync(long titleId, long userId);
        Task<long> InsertAsync(TitleAction action);
        Task UpdateAsync(TitleAction action);
    }
}
