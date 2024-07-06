using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.Entities.Traceability;

namespace SimpleForumApp.Application.Repositories.Traceability
{
    public interface IEndPointActivityRepository : IInjectable
    {
        Task<long> InsertAsync(EndPointActivity endPointActivity);
        Task UpdateAsync(EndPointActivity endPointActivity);
    }
}
