using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.DTOs.App.Group;
using SimpleForumApp.Domain.DTOs.App.Title;
using SimpleForumApp.Domain.Entities.App;

namespace SimpleForumApp.Application.Repositories.App
{
    public interface ITitleRepository : IInjectable
    {
        Task<long> InsertAsync(Title title);
        Task<IList<AgendaItem>> GetTitlesOpenedTodayAsAgendaAsync();
        Task<IList<Title>> GetAllAsync();
        Task<IList<TitlePreview>> GetAllForPreviewTitlesAsync(long? userId);
        Task<IList<Title>> GetTitlesFavouriteThisWeekAsync();
        Task<IList<WeeklyFavouriteGroup>> GetGroupsFavouriteThisWeekAsync();
    }
}

