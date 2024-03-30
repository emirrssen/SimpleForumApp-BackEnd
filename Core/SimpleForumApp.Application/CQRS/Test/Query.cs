using MediatR;
using SimpleForumApp.Application.BaseStructures.MediatR.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Application.CQRS.Test
{
    public class Query : QueryBase<string>
    {
        public long Id { get; set; }
    }
}
