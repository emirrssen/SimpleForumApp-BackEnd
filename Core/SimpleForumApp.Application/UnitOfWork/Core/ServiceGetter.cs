using Microsoft.Extensions.DependencyInjection;

namespace SimpleForumApp.Persistence.UnitOfWork.Core
{
    public abstract class ServiceGetter
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceGetter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected TService GetService<TService>() where TService : notnull
            => _serviceProvider.GetRequiredService<TService>();
    }
}
