using Microsoft.Extensions.Caching.Distributed;
using SimpleForumApp.Application.Services.Cache.Distributed;

namespace SimpleForumApp.Infrastructure.Services.Cache.Distributed
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDistributedCache _distributedCache;

        public RedisCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }


    }
}
