using SimpleForumApp.Persistence.EntityFrameworkCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories
{
    public class ReadRepository : WriteRepository
    {
        public ReadRepository(SimpleForumAppContext context) : base(context)
        {
            context.ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}
