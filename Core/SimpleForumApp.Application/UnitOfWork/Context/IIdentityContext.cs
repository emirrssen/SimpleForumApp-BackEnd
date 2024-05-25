using SimpleForumApp.Application.Services.Auth;

namespace SimpleForumApp.Application.UnitOfWork.Context
{
    public interface IIdentityContext
    {
        public IUserService UserService { get; }
        public IAuthService AuthService { get; }
        public ITokenService TokenService { get; }
    }
}
