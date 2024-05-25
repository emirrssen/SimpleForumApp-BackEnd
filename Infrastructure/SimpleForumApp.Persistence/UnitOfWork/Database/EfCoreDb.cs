using Microsoft.EntityFrameworkCore.Storage;
using SimpleForumApp.Application.UnitOfWork.Database;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;
using SimpleForumApp.Persistence.EntityFrameworkCore.Repositories;

namespace SimpleForumApp.Persistence.UnitOfWork.Database
{
    public class EfCoreDb : Repository, IEfCoreDb
    {
        public EfCoreDb(SimpleForumAppContext context) : base(context)
        {
        }

        public Task<IDbContextTransaction> BeginTransactionAsync() => _context.Database.BeginTransactionAsync();

        public async Task CommitTransactionAsync()
        {
            if (_context.Database.CurrentTransaction is not null)
            {
                await _context.Database.CurrentTransaction.CommitAsync();
            }
        }
        public async Task RollbackTransactionAsync()
        {
            if (_context.Database.CurrentTransaction is not null)
            {
                await _context.Database.CurrentTransaction.RollbackAsync();
            }
        }

        public async Task CreateSavepointAsync(string savepointName)
        {
            if (_context.Database.CurrentTransaction is not null)
            {
                await _context.Database.CurrentTransaction.CreateSavepointAsync(savepointName);
            }
        }

        public async Task RollbackToSavepointAsync(string savepointName)
        {
            if (_context.Database.CurrentTransaction is not null)
            {
                await _context.Database.CurrentTransaction.RollbackToSavepointAsync(savepointName);
            }
        }
    }
}
