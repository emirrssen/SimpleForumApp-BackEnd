using SimpleForumApp.Application.Services.Auth;

namespace SimpleForumApp.Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IAppUnitOfWork App { get; }
        public IIdentityUnitOfWork Identity { get; }
    }
}
