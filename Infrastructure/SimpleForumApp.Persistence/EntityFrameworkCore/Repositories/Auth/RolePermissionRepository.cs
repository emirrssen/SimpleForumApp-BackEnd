using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Repositories.Auth;
using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.Auth
{
    public class RolePermissionRepository : Repository, IRolePermissionRepository
    {
        public RolePermissionRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task<IList<RolePermission>> GetByPermissionIdAsync(long permissionId)
        {
            return await _context.RolePermissions
                .Where(x => x.PermissionId == permissionId && x.StatusId != 3)
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }

        public async Task<long> InsertAsync(RolePermission rolePermission)
        {
            var result = await _context.RolePermissions.AddAsync(rolePermission);
            await _context.SaveChangesAsync();

            return result.Entity.RoleId;
        }

        public async Task UpdateAsync(RolePermission rolePermission)
        {
            _context.RolePermissions.Update(rolePermission);
            await _context.SaveChangesAsync();
        }
    }
}
