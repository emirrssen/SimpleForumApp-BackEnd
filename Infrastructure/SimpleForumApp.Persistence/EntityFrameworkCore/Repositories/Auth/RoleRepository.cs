using SimpleForumApp.Application.Repositories.Auth;
using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.Auth
{
    public class RoleRepository : Repository, IRoleRepository
    {
        public RoleRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task<long> InsertAsync(Role role)
        {
            var result = await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task UpdateAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }
    }
}
