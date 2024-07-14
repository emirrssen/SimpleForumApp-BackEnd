using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.DTOs.Auth.EndPointClaimBusinessRule;

namespace SimpleForumApp.Application.Repositories.Auth
{
    public interface IEndPointClaimBusinessRuleRepository : IInjectable
    {
        Task<IList<EndPointClaimBusinessRuleDetail>> GetDetailsByEndPointIdAsync(long endPointId);
    }
}
