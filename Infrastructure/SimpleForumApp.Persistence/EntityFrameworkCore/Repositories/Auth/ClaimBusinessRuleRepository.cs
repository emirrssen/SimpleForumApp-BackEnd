using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Repositories.Auth;
using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.Auth
{
    public class ClaimBusinessRuleRepository : Repository, IClaimBusinessRuleRepository
    {
        public ClaimBusinessRuleRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task BulkInsertAsync(IList<ClaimBusinessRule> claims)
        {
            await _context.ClaimBusinessRules.AddRangeAsync(claims);
            await _context.SaveChangesAsync();
        }

        public async Task BulkUpdateAsync(IList<ClaimBusinessRule> claims)
        {
            _context.ClaimBusinessRules.UpdateRange(claims);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<ClaimBusinessRule>> GetAllAsync()
        {
            return await _context.ClaimBusinessRules.ToListAsync();
        }
    }
}
