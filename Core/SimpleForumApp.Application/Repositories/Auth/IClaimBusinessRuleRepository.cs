using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Application.Repositories.Auth
{
    public interface IClaimBusinessRuleRepository : IInjectable
    {
        Task<IList<ClaimBusinessRule>> GetAllAsync();
        Task BulkInsertAsync(IList<ClaimBusinessRule> claims);
        Task BulkUpdateAsync(IList<ClaimBusinessRule> claims);
    }
}
