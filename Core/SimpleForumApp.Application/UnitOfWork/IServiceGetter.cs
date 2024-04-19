namespace SimpleForumApp.Application.UnitOfWork
{
    public interface IServiceGetter
    {
        TService GetService<TService>() where TService : notnull;
    }
}
