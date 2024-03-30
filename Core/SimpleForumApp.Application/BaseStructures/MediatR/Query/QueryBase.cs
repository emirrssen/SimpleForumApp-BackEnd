using MediatR;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.BaseStructures.MediatR.Query
{
    public abstract class QueryBase<TResponse> : IRequest<ResultWithData<TResponse>>, IBase { }
}
