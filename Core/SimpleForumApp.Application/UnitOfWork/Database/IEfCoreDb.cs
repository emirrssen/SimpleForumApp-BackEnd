using Microsoft.EntityFrameworkCore.Storage;

namespace SimpleForumApp.Application.UnitOfWork.Database
{
    public interface IEfCoreDb
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        Task CreateSavepointAsync(string savepointName);
        Task RollbackToSavepointAsync(string savepointName);
    }
}
