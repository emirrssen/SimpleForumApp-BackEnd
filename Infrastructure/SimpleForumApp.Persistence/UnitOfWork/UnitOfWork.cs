using Microsoft.Extensions.DependencyInjection;
using SimpleForumApp.Application.Repositories;
using SimpleForumApp.Application.Services.Auth;
using SimpleForumApp.Application.UnitOfWork;

namespace SimpleForumApp.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public IStatusRepository StatusRepository => GetService<IStatusRepository>();
        public IGenderRepository GenderRepository => GetService<IGenderRepository>();
        public IUserService UserService => GetService<IUserService>();
        public IPersonRepository PersonRepository => GetService<IPersonRepository>();

        private TRepository GetService<TRepository>() where TRepository : notnull 
            => _serviceProvider.GetRequiredService<TRepository>();
    }
}
