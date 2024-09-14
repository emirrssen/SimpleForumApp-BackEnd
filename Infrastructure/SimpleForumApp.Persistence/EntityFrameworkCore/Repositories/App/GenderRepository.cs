using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Repositories.App;
using SimpleForumApp.Domain.Entities.App;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.App
{
    public class GenderRepository : Repository, IGenderRepository
    {
        public GenderRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task<IList<Gender>> GetAllAsync()
        {
            return await _context.Genders.ToListAsync();
        }
    }
}
