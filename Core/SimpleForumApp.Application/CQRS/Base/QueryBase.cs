using MediatR;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Domain.CQRS
{
    public abstract class QueryBase<TResponse> : IRequest<ResultWithData<TResponse>>
    {
    }
}
