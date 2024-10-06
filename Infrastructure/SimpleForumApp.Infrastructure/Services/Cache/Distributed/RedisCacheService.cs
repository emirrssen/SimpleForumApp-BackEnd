using Microsoft.Extensions.Caching.Distributed;
using SimpleForumApp.Application.Services.Cache.Distributed;
using System.Text;

namespace SimpleForumApp.Infrastructure.Services.Cache.Distributed
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDistributedCache _distributedCache;

        public RedisCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<string?> GetAsync(string key)
        {
            return await _distributedCache.GetStringAsync(key);
        }

        public async Task<bool> RemoveAsync(string key)
        {
            try
            {
                await _distributedCache.RemoveAsync(key);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<bool> SetAsync(string key, string value, int absoluteExpiration, int slidingExpiration)
        {
            try
            {
                await _distributedCache.SetStringAsync(key, value, options: new()
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(absoluteExpiration),
                    SlidingExpiration = TimeSpan.FromSeconds(slidingExpiration)
                });
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
