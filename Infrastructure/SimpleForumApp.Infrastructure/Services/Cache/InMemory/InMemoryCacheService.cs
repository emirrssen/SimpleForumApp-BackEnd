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

        public async Task<T> GetAsync<T>(string key)
        {
            if (_memoryCache.TryGetValue<T>(key, out T value))
            {
                return await Task.FromResult(value);
            }

            return await Task.FromResult(default(T));
        }

        public async Task<T> GetOrCreateAsync<T>(string key, T value, int absoluteExpiration, int slidingExpiration)
        {
            var result = _memoryCache.GetOrCreate<T>(key, entry =>
            {
                entry.AbsoluteExpiration = DateTime.Now.AddSeconds(absoluteExpiration);
                entry.SlidingExpiration = TimeSpan.FromSeconds(slidingExpiration);
                entry.SetValue(value);

                return value;
            });

            if (result != null)
            {
                return await Task.FromResult<T>(result);
            }

            return await Task.FromResult<T>(default(T));
        }

        public async Task<bool> RemoveAsync(string key)
        {
            try
            {
                _memoryCache.Remove(key);
            }
            catch
            {
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }

        public async Task<bool> SetAsync<T>(string key, T value, int absoluteExpiration, int slidingExpiration)
        {
            if (!_memoryCache.TryGetValue<T>(key, out _))
            {
                _memoryCache.Set<T>(key, value, options: new()
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(absoluteExpiration),
                    SlidingExpiration = TimeSpan.FromSeconds(slidingExpiration)
                });

                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }
    }
}
