using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Repositories.Auth;
using SimpleForumApp.Domain.DTOs.Auth.RolePermission;
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

        public async Task<RolePermission?> GetByRoleAndPermissionIdAsync(long roleId, long permissionId)
        {
            return await _context.RolePermissions
                .Where(x => x.RoleId == roleId && x.PermissionId == permissionId)
                .AsNoTrackingWithIdentityResolution()
                .SingleOrDefaultAsync();
        }

        public async Task<IList<RolePermission>> GetByRoleIdAsync(long roleId)
        {
            return await _context.RolePermissions
                .Where(x => x.RoleId == roleId && x.StatusId != 3)
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }

        public async Task<IList<RolePermissionDetail>> GetDetailsByRoleIdAsync(long roleId)
        {
            return await _context.RolePermissions
                .Where(x => x.RoleId == roleId && x.StatusId != 3)
                .Include(x => x.Role)
                .Include(x => x.Permission)
                .Include(x => x.Status)
                .Select(x => new RolePermissionDetail
                {
                    CreatedDate = x.CreatedDate,
                    PermissionId = x.PermissionId,
                    RoleId = x.RoleId,
                    StatusId = x.StatusId,
                    PermissionName = x.Permission.Name,
                    RoleName = x.Role.Name,
                    StatusName = x.Status.Name,
                    UpdatedDate = x.UpdatedDate
                })
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
