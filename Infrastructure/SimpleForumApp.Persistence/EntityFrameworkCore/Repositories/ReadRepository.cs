using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

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
