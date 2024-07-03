using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.DTOs.App;
using SimpleForumApp.Domain.Entities.App;

namespace SimpleForumApp.Application.Repositories.App
{
    public interface IPersonRepository : IInjectable
    {
        Task<IList<PersonDetails>> GetAllPersonDetailsAsync();
        Task<long> InsertAsync(Person person);
        Task<bool> DeleteByIdAsync(long id);
    }
}
