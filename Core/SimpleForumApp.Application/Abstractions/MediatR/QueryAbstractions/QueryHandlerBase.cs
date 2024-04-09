using MediatR;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions
{
    public abstract class QueryHandlerBase<TQuery, TResponse> : IRequestHandler<TQuery, ResultWithData<TResponse>> where TQuery : QueryBase<TResponse>
    {
        public abstract Task<ResultWithData<TResponse>> Handle(TQuery request, CancellationToken cancellationToken);
    }
}
