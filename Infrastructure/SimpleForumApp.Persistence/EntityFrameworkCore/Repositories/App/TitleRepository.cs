using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Repositories.App;
using SimpleForumApp.Domain.DTOs.App.Title;
using SimpleForumApp.Domain.Entities.App;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.App
{
    public class TitleRepository : Repository, ITitleRepository
    {
        public TitleRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task<IList<Title>> GetAllAsync()
        {
            return await _context.Titles
                .Where(x => x.StatusId != 3)
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }

        public async Task<IList<TitlePreview>> GetAllForPreviewTitlesAsync()
        {
            return await _context.Titles
                .Where(x => x.StatusId != 3)
                .Include(x => x.Author)
                    .ThenInclude(x => x.User)
                    .ThenInclude(x => x.Person)
                .Include(x => x.Author)
                    .ThenInclude(x => x.Group)
                .Include(x => x.Actions)
                .Select(x => new TitlePreview
                {
                    AuthorId = x.AuthorId,
                    AuthorName = x.Author.AuthorTypeId == 1 ? x.Author.User.UserName ?? "" : x.Author.Group.Name,
                    AuthorProfileImage = x.Author.AuthorTypeId == 1 ? x.Author.User.Person.ProfileImage : x.Author.Group.GroupImage,
                    Content = x.Content,
                    CreatedDate = x.CreatedDate,
                    Id = x.Id,
                    LikeNumber = x.Actions.Where(y => y.ActionId == 1 && y.StatusId == 1).Count(),
                    Subject = x.Subject
                })
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }

        public async Task<IList<AgendaItem>> GetTitlesOpenedTodayAsAgendaAsync()
        {
            return await _context.Titles
                .Where(x => x.CreatedDate.Date == DateTime.Now.Date && x.StatusId == 1)
                .Include(x => x.Entries)
                .Select(x => new AgendaItem
                {
                    Id = x.Id,
                    EntryNumbers = x.Entries.Count(),
                    TitleSubject = x.Subject
                })
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }

        public async Task<long> InsertAsync(Title title)
        {
            var result = await _context.Titles.AddAsync(title);
            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }
    }
}
