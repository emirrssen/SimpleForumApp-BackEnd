using SimpleForumApp.Application.Services.Auth;
using SimpleForumApp.Application.UnitOfWork.Context;
using SimpleForumApp.Persistence.UnitOfWork.Core;

namespace SimpleForumApp.Persistence.UnitOfWork.Context
{
    public class IdentityContext : ServiceGetter, IIdentityContext
    {
        public IdentityContext(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public IUserService UserService => GetService<IUserService>();
        public IAuthService AuthService => GetService<IAuthService>();
        public ITokenService TokenService => GetService<ITokenService>();
    }
}
