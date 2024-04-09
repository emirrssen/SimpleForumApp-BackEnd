using SimpleForumApp.Application.Repositories;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;
using SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories
{
    public class GenderRepository : Repository, IGenderRepository
    {
        public GenderRepository(SimpleForumAppContext context) : base(context)
        {
        }
    }
}
