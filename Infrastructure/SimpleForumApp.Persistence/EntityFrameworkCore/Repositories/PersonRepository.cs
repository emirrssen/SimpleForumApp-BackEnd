using SimpleForumApp.Application.Repositories;
using SimpleForumApp.Domain.Entities.App;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;
using SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories
{
    public class PersonRepository : Repository, IPersonRepository
    {
        public PersonRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task<long> InsertAsync(Person person)
        {
            var result = await _context.Persons.AddAsync(person);

            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }
    }
}
