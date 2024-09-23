using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Repositories.Auth;
using SimpleForumApp.Domain.DTOs.Auth.PermissionDtos;
using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.Auth
{
    public class PermissionRepository : Repository, IPermissionRepository
    {
        public PermissionRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task<IList<PermissionDetails>> GetAllDetailsAsync()
        {
            var result = await _context.Permissions
                .Where(x => x.StatusId == 1)
                .Include(x => x.Status)
                .Select(x => new PermissionDetails
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedDate = x.CreatedDate,
                    Description = x.Description,
                    StatusId = x.StatusId,
                    StatusName = x.Status.Name,
                    UpdatedDate = x.UpdatedDate
                }).AsNoTrackingWithIdentityResolution()
                .ToListAsync();

            return result;
        }

        public async Task<IList<PermissionDetails>> GetAllDetailsByStatusAsync(long statusId)
        {
            return await _context.Permissions
                .Where(x => x.StatusId == statusId)
                .Include(x => x.Status)
                .Select(x => new PermissionDetails
                {
                    Id = x.Id,
                    StatusId = x.StatusId,
                    Description = x.Description,
                    CreatedDate = x.CreatedDate,
                    Name = x.Name,
                    StatusName = x.Status.Name,
                    UpdatedDate = x.UpdatedDate
                })
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }

        public async Task<long> InsertAsync(Permission permission)
        {
            var result = await _context.Permissions.AddAsync(permission);
            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task UpdateAsync(Permission permission)
        {
            _context.Permissions.Update(permission);
            await _context.SaveChangesAsync();
        }
    }
}
