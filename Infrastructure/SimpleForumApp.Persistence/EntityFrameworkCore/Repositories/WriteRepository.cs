using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories
{
    public class WriteRepository : Repository
    {
        public WriteRepository(SimpleForumAppContext context) : base(context)
        {
        }
    }
}
