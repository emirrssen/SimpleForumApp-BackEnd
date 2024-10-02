using SimpleForumApp.Application.UnitOfWork.Core;

namespace SimpleForumApp.Application.Services.Cache.InMemory
{
    public interface IInMemoryCacheService : IInjectable
    {
        Task SetAsync<T>(T entity);
        Task<T> GetAsync<T>(string key);
        Task RemoveAsync(string key);
    }
}
