using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.DTOs.Traceability.EndPoint;
using SimpleForumApp.Domain.Entities.Traceability;

namespace SimpleForumApp.Application.Repositories.Traceability
{
    public interface IEndPointRepository : IInjectable
    {
        Task BulkInsertAsync(IList<EndPoint> endPoints);
        Task BulkUpdateAsync(IList<EndPoint> endPoints);
        Task<IList<EndPoint>> GetAllAsync();
        Task UpdateEndPoint(EndPoint endPoint);
        Task<EndPoint> GetByRouteAndActionTypeId(string route, long actionTypeId);
        Task<IList<EndPointToList>> GetDetailsByStatusAsync(bool isActive);
    }
}
