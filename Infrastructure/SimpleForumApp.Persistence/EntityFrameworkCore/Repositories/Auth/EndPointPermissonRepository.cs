using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Repositories.Auth;
using SimpleForumApp.Domain.DTOs.Auth.EndPointPermission;
using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.Auth
{
    public class EndPointPermissonRepository : Repository, IEndPointPermissionRepository
    {
        public EndPointPermissonRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task BulkUpdateAsync(EndPointPermission[] endPointPermissions)
        {
            _context.EndPointPermissions.UpdateRange(endPointPermissions);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<EndPointPermissionDetail>> GetAllPermissionDetailsByEndPointAsync(long endpointId)
        {
            return await _context.EndPointPermissions
                .Where(x => x.EndPointId == endpointId && x.StatusId != 3)
                .Include(x => x.EndPoint)
                .Include(x => x.Permission)
                .Include(x => x.Status)
                .Select(x => new EndPointPermissionDetail
                {
                    EndPointId = x.EndPointId,
                    CreatedDate = x.CreatedDate,
                    EndPointMethodName = x.EndPoint.MethodName,
                    EndPointControllerName = x.EndPoint.ControllerName,
                    EndPointRoute = x.EndPoint.EndPointRoute,
                    PermissonId = x.PermissionId,
                    PermissionName = x.Permission.Name,
                    StatusId = x.StatusId,
                    StatusName = x.Status.Name
                    
                })
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }

        public async Task<IList<EndPointPermission>> GetAllPermissionsByEndPointAsync(long endPointId)
        {
            var result = await _context.EndPointPermissions
                .Where(x => x.EndPointId == endPointId)
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();

            return result;
        }

        public async Task<EndPointPermission?> GetByEndPointAndPermissionIdAsync(long endpointId, long permissionId)
        {
            return await _context.EndPointPermissions
                .Where(x => x.EndPointId == endpointId && x.PermissionId == permissionId)
                .AsNoTrackingWithIdentityResolution()
                .SingleOrDefaultAsync();
        }

        public async Task<IList<EndPointPermission>> GetByPermissionIdAsync(long permissionId)
        {
            return await _context.EndPointPermissions
                .Where(x => x.PermissionId == permissionId && x.StatusId != 3)
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
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
