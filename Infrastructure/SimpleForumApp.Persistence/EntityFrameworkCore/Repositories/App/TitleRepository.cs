using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Repositories.App;
using SimpleForumApp.Domain.DTOs.App.Group;
using SimpleForumApp.Domain.DTOs.App.Title;
using SimpleForumApp.Domain.Entities.App;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;
using System.Globalization;

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

        public async Task<IList<TitlePreview>> GetAllForPreviewTitlesAsync(long? userId)
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
                    Subject = x.Subject,
                    ActionId = x.Actions.FirstOrDefault(x => x.StatusId == 1 && x.UserId == userId).ActionId
                })
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }

        public async Task<IList<WeeklyFavouriteGroup>> GetGroupsFavouriteThisWeekAsync()
        {
            return await _context.WeeklyFavouriteGroups.OrderByDescending(x => x.LikeNumber).ToListAsync();
        }

        public async Task<IList<Title>> GetTitlesFavouriteThisWeekAsync()
        {
            DateTime now = DateTime.Now;
            CultureInfo culture = CultureInfo.CurrentCulture;
            Calendar calendar = culture.Calendar;

            CalendarWeekRule rule = culture.DateTimeFormat.CalendarWeekRule;
            DayOfWeek firstDayOfWeek = culture.DateTimeFormat.FirstDayOfWeek;

            int weekNumber = calendar.GetWeekOfYear(now, rule, firstDayOfWeek);

            var titles = await _context.Titles
                .Where(x => x.StatusId == 1)
                .Include(x => x.Actions)
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();

            var filteredTitles = titles
                .Where(x => calendar.GetWeekOfYear(x.CreatedDate, rule, firstDayOfWeek) == weekNumber)
                .OrderByDescending(x => x.Actions.Where(a => a.StatusId == 1 && a.ActionId == 1).Count())
                .Take(5)
                .ToList();

            return filteredTitles;
        }

        public async Task<IList<AgendaItem>> GetTitlesOpenedTodayAsAgendaAsync()
        {
            return await _context.Titles
                .Where(x => x.CreatedDate.Date == DateTime.Now.Date && x.StatusId == 1)
                .Include(x => x.Entries)
                .OrderByDescending(x => x.CreatedDate)
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
