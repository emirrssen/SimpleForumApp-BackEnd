using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Repositories.Auth;
using SimpleForumApp.Domain.DTOs.Auth.EndPointClaimBusinessRule;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.Auth
{
    public class EndPointClaimBusinessRuleRepository : Repository, IEndPointClaimBusinessRuleRepository
    {
        public EndPointClaimBusinessRuleRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task<IList<EndPointClaimBusinessRuleDetail>> GetDetailsByEndPointIdAsync(long endPointId)
        {
            var result = await _context.EndPointClaimBusinessRules
                .Where(x => x.EndPointId == endPointId)
                .Include(x => x.ClaimBusinessRule)
                .Select(x => new EndPointClaimBusinessRuleDetail
                {
                    EndPointId = x.EndPointId,
                    ClaimBusinessRuleId = x.ClaimBusinessRuleId,
                    Code = x.ClaimBusinessRule.Code,
                    ExecutionOrderId = x.ClaimBusinessRule.ExecutionOrderId,
                    Priority = x.ClaimBusinessRule.Priority
                })
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();

            return result;
        }
    }
}
