namespace SimpleForumApp.Application.UnitOfWork.Database
{
    public interface IDatabase
    {
        public IEfCoreDb EfCoreDb { get; }
    }
}
