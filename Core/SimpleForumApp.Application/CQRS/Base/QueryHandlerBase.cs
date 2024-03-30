using MediatR;
using SimpleForumApp.Domain.CQRS;
using SimpleForumApp.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Application.CQRS.Base
{
    public abstract class QueryHandlerBase<TQuery, TResponse> : IRequestHandler<TQuery, ResultWithData<TResponse>> where TQuery : QueryBase<TResponse>
    {
        public abstract Task<ResultWithData<TResponse>> Handle(TQuery request, CancellationToken cancellationToken);
    }
}
