using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Repositories.Auth;
using SimpleForumApp.Domain.DTOs.Auth.RoleDtos;
using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.Auth
{
    public class RoleRepository : Repository, IRoleRepository
    {
        public RoleRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task<IList<Role>> GetAllAsync()
        {
            return await _context.Roles
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }

        public async Task<IList<RoleToList>> GetAllDetailsByStatusAsync(long statusId)
        {
            return await _context.Roles
                .Where(x => x.StatusId == statusId)
                .Include(x => x.Status)
                .Select(x => new RoleToList
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    StatusName = x.Status.Name
                })
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
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
