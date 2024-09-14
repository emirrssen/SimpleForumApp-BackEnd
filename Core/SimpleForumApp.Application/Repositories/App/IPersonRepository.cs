using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.DTOs.App.Person;
using SimpleForumApp.Domain.Entities.App;

namespace SimpleForumApp.Application.Repositories.App
{
    public interface IPersonRepository : IInjectable
    {
        Task<IList<PersonDetails>> GetAllPersonDetailsAsync();
        Task<Person> GetByIdAsync(long id);
        Task<long> InsertAsync(Person person);
        Task DeleteByIdAsync(Person person);
    }
}
