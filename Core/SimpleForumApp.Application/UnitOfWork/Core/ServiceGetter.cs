using Microsoft.Extensions.DependencyInjection;
using SimpleForumApp.Application.UnitOfWork.Core;

namespace SimpleForumApp.Persistence.UnitOfWork.Core
{
    public abstract class ServiceGetter
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceGetter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected TService GetService<TService>() where TService : notnull, IService
            => _serviceProvider.GetRequiredService<TService>();
    }
}
