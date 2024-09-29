﻿using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Repositories.Auth;
using SimpleForumApp.Domain.DTOs.Auth.UserRole;
using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.Auth
{
    public class UserRoleRepository : Repository, IUserRoleRepository
    {
        public UserRoleRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task<long[]> GetAllUserPermissionsByUserIdAsync(long userId)
        {
            var resultToReturn = new List<long>();

            await _context.UserRoles
                .Where(x => x.UserId == userId)
                .Include(x => x.Role)
                    .ThenInclude(x => x.Permissions)
                    .Where(x => x.Role.Permissions.All(y => y.StatusId == 1))
                .AsNoTrackingWithIdentityResolution()
                .ForEachAsync(x => 
                {
                    resultToReturn.AddRange(x.Role.Permissions.Select(x => x.PermissionId).ToList());
                });

            return resultToReturn.ToArray();
        }

        public async Task<IList<UserRole>> GetByUserIdAsync(long userId)
        {
            return await _context.UserRoles
                .Where(x => x.UserId == userId && x.StatusId == 1)
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }

        public async Task<IList<UserRoleDetail>> GetDetailsByUserIdAsync(long userId)
        {
            return await _context.UserRoles
                .Where(x => x.UserId == userId && x.StatusId == 1)
                .Include(x => x.User)
                .Include(x => x.Role)
                .Include(x => x.Status)
                .Select(x => new UserRoleDetail
                {
                    RoleId = x.RoleId,
                    CreatedDate = x.CreatedDate,
                    RoleName = x.Role.Name,
                    StatusId = x.StatusId,
                    StatusName = x.Status.Name,
                    UpdatedDate = x.UpdatedDate,
                    UserId = x.UserId,
                    Username = x.User.UserName
                })
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }

        public async Task<long> InsertAsync(UserRole userRole)
        {
            var result = await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();

            return result.Entity.UserId;
        }

        public async Task UpdateAsync(UserRole userRole)
        {
            _context.UserRoles.Update(userRole);
            await _context.SaveChangesAsync();
        }
    }
}
