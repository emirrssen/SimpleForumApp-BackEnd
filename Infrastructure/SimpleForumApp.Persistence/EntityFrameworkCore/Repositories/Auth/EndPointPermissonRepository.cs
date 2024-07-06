using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Repositories.Auth;
using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.Auth
{
    public class EndPointPermissonRepository : Repository, IEndPointPermissionRepository
    {
        public EndPointPermissonRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task<IList<EndPointPermission>> GetAllPermissionsByEndPointAsync(long endPointId)
        {
            var result = await _context.EndPointPermissions
                .Where(x => x.EndPointId == endPointId)
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();

            return result;
        }

        public async Task<long> InsertAsync(EndPointPermission endPointPermission)
        {
            var result = await _context.EndPointPermissions.AddAsync(endPointPermission);
            await _context.SaveChangesAsync();

            return result.Entity.EndPointId;
        }

        public async Task UpdateAsync(EndPointPermission endPointPermission)
        {
            _context.EndPointPermissions.Update(endPointPermission);
            await _context.SaveChangesAsync();
        }
    }
}
