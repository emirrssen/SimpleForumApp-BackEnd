using SimpleForumApp.Application.Repositories.App;
using SimpleForumApp.Domain.Entities.App;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.App
{
    public class TitleRepository : Repository, ITitleRepository
    {
        public TitleRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task<long> InsertAsync(Title title)
        {
            var result = await _context.Titles.AddAsync(title);
            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }
    }
}
