using Microsoft.Extensions.DependencyInjection;
using SimpleForumApp.Application.Repositories;
using SimpleForumApp.Application.UnitOfWork;

namespace SimpleForumApp.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public IStatusRepository StatusRepository => GetRequiredRepository<IStatusRepository>();
        public IGenderRepository GenderRepository => GetRequiredRepository<IGenderRepository>();

        private TRepository GetRequiredRepository<TRepository>() where TRepository : notnull 
            => _serviceProvider.GetRequiredService<TRepository>();
    }
}
