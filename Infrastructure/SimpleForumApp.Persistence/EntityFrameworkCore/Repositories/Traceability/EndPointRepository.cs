using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Repositories.Traceability;
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

        public async Task UpdateEndPoint(EndPoint endPoint)
        {
            _context.EndPoints.Update(endPoint);

            await _context.SaveChangesAsync();
        }
    }
}
