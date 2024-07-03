using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.Entities.Traceability;

namespace SimpleForumApp.Application.Repositories.Traceability
{
    public interface IEndPointRepository : IInjectable
    {
        Task BulkInsertAsync(IList<EndPoint> endPoints);
        Task BulkUpdateAsync(IList<EndPoint> endPoints);
        Task<IList<EndPoint>> GetAllAsync();
        Task UpdateEndPoint(EndPoint endPoint);
    }
}
