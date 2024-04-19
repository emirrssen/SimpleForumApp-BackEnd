using Microsoft.Extensions.DependencyInjection;
using SimpleForumApp.Application.UnitOfWork;

namespace SimpleForumApp.Persistence.UnitOfWork
{
    public class ServiceGetter : IServiceGetter
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceGetter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TService GetService<TService>() where TService : notnull 
            => _serviceProvider.GetRequiredService<TService>();
    }
}
