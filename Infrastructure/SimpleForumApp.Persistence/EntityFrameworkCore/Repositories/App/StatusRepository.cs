using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Repositories.App;
using SimpleForumApp.Domain.Entities.Core;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.App
{
    public class StatusRepository : Repository, IStatusRepository
    {
        public StatusRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task<IList<Status>> GetAllAsync()
        {
            return await _context.Statuses.ToListAsync();
        }
    }
}
