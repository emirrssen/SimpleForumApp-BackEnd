using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.Core
{
    public abstract class Repository
    {
        protected readonly SimpleForumAppContext _context;

        protected Repository(SimpleForumAppContext context)
        {
            _context = context;
        }
    }
}
