using MediatR;
using SimpleForumApp.Application.CQRS.Base;
using SimpleForumApp.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Application.CQRS.Operations.Test
{
    public class Handler : QueryHandlerBase<Query, string>
    {
        public override Task<ResultWithData<string>> Handle(Query request, CancellationToken cancellationToken)
        {
            throw new Exception("Hata");
        }
    }
}
