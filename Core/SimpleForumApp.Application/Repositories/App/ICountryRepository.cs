using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.Entities.App;

namespace SimpleForumApp.Application.Repositories.App
{
    public interface ICountryRepository : IInjectable
    {
        Task<IList<Country>> GetAllAsync();
    }
}
