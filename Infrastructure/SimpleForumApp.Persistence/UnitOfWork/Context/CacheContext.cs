using SimpleForumApp.Application.Services.Cache.Distributed;
using SimpleForumApp.Application.Services.Cache.InMemory;
using SimpleForumApp.Application.UnitOfWork.Context;
using SimpleForumApp.Persistence.UnitOfWork.Core;

namespace SimpleForumApp.Persistence.UnitOfWork.Context
{
    public class CacheContext : ServiceGetter, ICacheContext
    {
        public CacheContext(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public IInMemoryCacheService InMemoryCacheService => GetService<IInMemoryCacheService>();
        public IRedisCacheService RedisCacheService => GetService<IRedisCacheService>();
    }
}
