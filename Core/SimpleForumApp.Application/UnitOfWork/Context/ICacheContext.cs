using SimpleForumApp.Application.Services.Cache.InMemory;
using SimpleForumApp.Application.UnitOfWork.Core;

namespace SimpleForumApp.Application.UnitOfWork.Context
{
    public interface ICacheContext : IInjectable
    {
        public IInMemoryCacheService InMemoryCacheService { get; }
    }
}
