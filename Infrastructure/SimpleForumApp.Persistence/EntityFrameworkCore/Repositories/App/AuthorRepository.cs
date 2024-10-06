using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Repositories.App;
using SimpleForumApp.Domain.DTOs.App.Author;
using SimpleForumApp.Domain.Entities.App;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.App
{
    public class AuthorRepository : Repository, IAuthorRepository
    {
        public AuthorRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task<Author?> GetByUserIdAsync(long userId)
        {
            return await _context.Authors
                .Where(x => x.UserId == userId && x.AuthorTypeId == 1)
                .AsNoTrackingWithIdentityResolution()
                .SingleOrDefaultAsync();
        }

        public async Task<IList<WeeklyFavouriteAuthor>> GetWeeklyFavouriteAuthorsAsync()
        {
            return await _context.WeeklyFavouriteAuthors.OrderByDescending(x => x.LikeNumber).ToListAsync();        
        }

        public async Task<long> InsertAsync(Author author)
        {
            var result = await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }
    }
}
