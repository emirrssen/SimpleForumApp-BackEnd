using SimpleForumApp.Application.UnitOfWork.Core;

namespace SimpleForumApp.Application.Services.Cache.Distributed
{
    public interface IRedisCacheService : IInjectable
    {
        Task<string?> GetAsync(string key);
        Task<bool> SetAsync(string key, string value, int absoluteExpiration, int slidingExpiration);
        Task<bool> RemoveAsync(string key);
    }
}
