using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Repositories.App;
using SimpleForumApp.Domain.Entities.App;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.App
{
    public class CountryRepository : Repository, ICountryRepository
    {
        public CountryRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task<IList<Country>> GetAllAsync()
        {
            return await _context.Countries.ToListAsync();
        }
    }
}
