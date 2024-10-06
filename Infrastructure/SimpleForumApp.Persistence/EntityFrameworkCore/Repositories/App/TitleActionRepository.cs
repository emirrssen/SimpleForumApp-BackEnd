using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Repositories.App;
using SimpleForumApp.Domain.Entities.App;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.App
{
    public class TitleActionRepository : Repository, ITitleActionRepository
    {
        public TitleActionRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task<IList<TitleAction>> GetByTitleIdAndUserIdAsync(long titleId, long userId)
        {
            return await _context.TitleActions
                .Where(x => x.UserId == userId && x.TitleId == titleId)
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }

        public async Task<long> InsertAsync(TitleAction action)
        {
            var result = await _context.TitleActions.AddAsync(action);
            await _context.SaveChangesAsync();

            return result.Entity.TitleId;
        }

        public async Task UpdateAsync(TitleAction action)
        {
            _context.TitleActions.Update(action);
            await _context.SaveChangesAsync();
        }
    }
}
