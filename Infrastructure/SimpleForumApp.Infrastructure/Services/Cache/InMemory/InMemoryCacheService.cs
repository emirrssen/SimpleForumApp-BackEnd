using Microsoft.Extensions.Caching.Memory;
using SimpleForumApp.Application.Services.Cache.InMemory;

namespace SimpleForumApp.Infrastructure.Services.Cache.InMemory
{
    public class InMemoryCacheService : IInMemoryCacheService
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<T> GetAsync<T>(string key)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task SetAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
