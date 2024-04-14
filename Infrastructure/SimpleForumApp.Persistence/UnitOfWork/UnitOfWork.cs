using Microsoft.Extensions.DependencyInjection;
using SimpleForumApp.Application.Repositories.PersonRepositories;
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

        public IUserService UserService => GetService<IUserService>();
        public IPersonWriteRepository PersonRepository => GetService<IPersonWriteRepository>();
        public IAuthService AuthService => GetService<IAuthService>();

        private TRepository GetService<TRepository>() where TRepository : notnull 
            => _serviceProvider.GetRequiredService<TRepository>();
    }
}
