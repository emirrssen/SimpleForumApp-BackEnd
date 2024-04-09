using MediatR;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions
{
    public abstract class QueryBase<TResponse> : IRequest<ResultWithData<TResponse>>, IMediatrAbstractionCore { }
}
