using SimpleForumApp.Application.UnitOfWork.Core;

namespace SimpleForumApp.Application.Services.Cache.InMemory
{
    public interface IInMemoryCacheService : IInjectable
    {
        Task<bool> SetAsync<T>(string key, T value, int absoluteExpiration, int slidingExpiration);
        Task<T> GetAsync<T>(string key);
        Task<bool> RemoveAsync(string key);
        Task<T> GetOrCreateAsync<T>(string key, T value, int absoluteExpiration, int slidingExpiration);
    }
}
