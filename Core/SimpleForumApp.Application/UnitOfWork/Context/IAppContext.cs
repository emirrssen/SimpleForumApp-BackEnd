using SimpleForumApp.Application.Repositories.App;
using SimpleForumApp.Application.UnitOfWork.Core;

namespace SimpleForumApp.Application.UnitOfWork.Context
{
    public interface IAppContext : IInjectable
    {
        public IPersonRepository PersonRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public IGenderRepository GenderRepository { get; }
    }
}
