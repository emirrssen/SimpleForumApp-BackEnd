using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories
{
    public abstract class Repository
    {
        protected readonly SimpleForumAppContext _context;

        protected Repository(SimpleForumAppContext context)
        {
            _context = context;
        }

        protected Task SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
