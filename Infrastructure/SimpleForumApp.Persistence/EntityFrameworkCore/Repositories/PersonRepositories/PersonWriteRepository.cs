using SimpleForumApp.Application.Repositories.PersonRepositories;
using SimpleForumApp.Domain.Entities.App;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.PersonRepositories
{
    public class PersonWriteRepository : WriteRepository, IPersonWriteRepository
    {
        public PersonWriteRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task<bool> DeleteByIdAsync(long id)
        {
            var personToDelete = await _context.Persons.FindAsync(id);

            if (personToDelete is null)
                return false;

            _context.Persons.Remove(personToDelete!);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<long> InsertAsync(Person person)
        {
            var result = await _context.Persons.AddAsync(person);

            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }
    }
}
