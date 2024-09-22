using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Repositories.Traceability;
using SimpleForumApp.Domain.DTOs.Traceability.EndPoint;
using SimpleForumApp.Domain.Entities.Traceability;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.Traceability
{
    public class EndPointRepository : Repository, IEndPointRepository
    {
        public EndPointRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task BulkInsertAsync(IList<EndPoint> endPoints)
        {
            await _context.EndPoints.AddRangeAsync(endPoints);
            await _context.SaveChangesAsync();
        }

        public async Task BulkUpdateAsync(IList<EndPoint> endPoints)
        {
            _context.EndPoints.UpdateRange(endPoints);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<EndPoint>> GetAllAsync()
        {
            var result = await _context.EndPoints.AsNoTrackingWithIdentityResolution().ToListAsync();

            return result.ToList();
        }

        public async Task<EndPoint> GetByRouteAndActionTypeId(string route, long actionTypeId)
        {
            var result = await _context.EndPoints
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(x => x.EndPointRoute == route && x.ActionTypeId == actionTypeId);

            return result;
        }

        public async Task<IList<EndPointToList>> GetDetailsByStatusAsync(bool isActive)
        {
            return await _context.EndPoints
                .Where(x => x.IsActive == isActive)
                .Include(x => x.ActionType)
                .Select(x => new EndPointToList
                {
                    Id = x.Id,
                    ActionMethodName = x.ActionType.Name,
                    ControllerName = x.ControllerName,
                    IsActive = x.IsActive,
                    IsUse = x.IsUse,
                    MethodName = x.MethodName,
                    Route = x.EndPointRoute
                })
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }

        public async Task UpdateEndPoint(EndPoint endPoint)
        {
            _context.EndPoints.Update(endPoint);
            await _context.SaveChangesAsync();
        }
    }
}
