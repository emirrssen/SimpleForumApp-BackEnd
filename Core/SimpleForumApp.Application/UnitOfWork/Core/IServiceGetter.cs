namespace SimpleForumApp.Application.UnitOfWork.Core
{
    public interface IServiceGetter
    {
        TService GetService<TService>() where TService : notnull;
    }
}
