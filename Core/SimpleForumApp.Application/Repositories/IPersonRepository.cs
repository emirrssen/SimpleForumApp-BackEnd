using SimpleForumApp.Domain.Entities.App;

namespace SimpleForumApp.Application.Repositories
{
    public interface IPersonRepository
    {
        Task<long> InsertAsync(Person person);
    }
}
