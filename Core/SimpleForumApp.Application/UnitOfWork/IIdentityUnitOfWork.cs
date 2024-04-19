using SimpleForumApp.Application.Services.Auth;

namespace SimpleForumApp.Application.UnitOfWork
{
    public interface IIdentityUnitOfWork
    {
        public IUserService UserService { get; }
        public IAuthService AuthService { get; }
        public ITokenService TokenService { get; }
    }
}
