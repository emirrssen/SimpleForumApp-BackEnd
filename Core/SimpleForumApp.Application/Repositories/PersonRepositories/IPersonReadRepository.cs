using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.DTOs.App;

namespace SimpleForumApp.Application.Repositories.PersonRepositories
{
    public interface IPersonReadRepository : IInjectable
    {
        Task<IList<PersonDetails>> GetAllPersonDetailsAsync();
    }
}
