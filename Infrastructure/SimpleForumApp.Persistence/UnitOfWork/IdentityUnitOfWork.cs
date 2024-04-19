using SimpleForumApp.Application.Services.Auth;
using SimpleForumApp.Application.UnitOfWork;

namespace SimpleForumApp.Persistence.UnitOfWork
{
    public class IdentityUnitOfWork : ServiceGetter, IIdentityUnitOfWork
    {
        public IdentityUnitOfWork(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public IUserService UserService => GetService<IUserService>();
        public IAuthService AuthService => GetService<IAuthService>();
        public ITokenService TokenService => GetService<ITokenService>();
    }
}
