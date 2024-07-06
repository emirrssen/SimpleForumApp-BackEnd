using SimpleForumApp.Application.Repositories.Traceability;
using SimpleForumApp.Application.UnitOfWork.Context;
using SimpleForumApp.Persistence.UnitOfWork.Core;

namespace SimpleForumApp.Persistence.UnitOfWork.Context
{
    public class TraceabilityContext : ServiceGetter, ITraceabilityContext
    {
        public TraceabilityContext(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public IEndPointRepository EndPointRepository => GetService<IEndPointRepository>();
        public IEndPointActivityRepository EndPointActivityRepository => GetService<IEndPointActivityRepository>();
    }
}
