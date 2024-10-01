using SimpleForumApp.Application.Repositories.App;
using SimpleForumApp.Domain.Entities.App;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.App
{
    public class EntryRepository : Repository, IEntryRepository
    {
        public EntryRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task<long> InsertAsync(Entry entry)
        {
            var result = await _context.Entries.AddAsync(entry);
            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }
    }
}
