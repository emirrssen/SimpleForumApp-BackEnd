using Microsoft.EntityFrameworkCore.Storage;
using SimpleForumApp.Application.UnitOfWork.Core;

namespace SimpleForumApp.Application.UnitOfWork.Database
{
    public interface IEfCoreDb : IInjectable
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        Task CreateSavepointAsync(string savepointName);
        Task RollbackToSavepointAsync(string savepointName);
    }
}
