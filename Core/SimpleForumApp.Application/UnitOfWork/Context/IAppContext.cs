using SimpleForumApp.Application.Repositories.App;
using SimpleForumApp.Application.UnitOfWork.Core;

namespace SimpleForumApp.Application.UnitOfWork.Context
{
    public interface IAppContext : IInjectable
    {
        public IPersonRepository PersonRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public IGenderRepository GenderRepository { get; }
        public IStatusRepository StatusRepository { get; }
        public ITitleRepository TitleRepository { get; }
        public IAuthorRepository AuthorRepository { get; }
        public ITitleActionRepository TitleActionRepository { get; }
        public IEntryRepository EntryRepository { get; }
    }
}
