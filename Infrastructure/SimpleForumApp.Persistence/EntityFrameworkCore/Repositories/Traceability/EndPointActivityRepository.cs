using SimpleForumApp.Application.Repositories.Traceability;
using SimpleForumApp.Domain.Entities.Traceability;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.Traceability
{
    public class EndPointActivityRepository : Repository, IEndPointActivityRepository
    {
        public EndPointActivityRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task<long> InsertAsync(EndPointActivity endPointActivity)
        {
            var result = await _context.EndPointActivities.AddAsync(endPointActivity);
            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task UpdateAsync(EndPointActivity endPointActivity)
        {
            var result = _context.EndPointActivities.Update(endPointActivity);
            await _context.SaveChangesAsync();
        }
    }
}
