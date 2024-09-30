using SimpleForumApp.Application.Repositories.App;
using SimpleForumApp.Application.Repositories.Traceability;
using SimpleForumApp.Application.UnitOfWork.Context;
using SimpleForumApp.Persistence.UnitOfWork.Core;

namespace SimpleForumApp.Persistence.UnitOfWork.Context
{
    public class AppContext : ServiceGetter, IAppContext
    {
        public AppContext(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public IEndPointRepository EndPointRepository => GetService<IEndPointRepository>();
        public IPersonRepository PersonRepository => GetService<IPersonRepository>();
        public ICountryRepository CountryRepository => GetService<ICountryRepository>();
        public IGenderRepository GenderRepository => GetService<IGenderRepository>();
        public IStatusRepository StatusRepository => GetService<IStatusRepository>();
        public ITitleRepository TitleRepository => GetService<ITitleRepository>();
        public IAuthorRepository AuthorRepository => GetService<IAuthorRepository>();
    }
}
