using SimpleForumApp.Application.Repositories.PersonRepositories;
using SimpleForumApp.Application.Services.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IPersonWriteRepository PersonRepository { get; }
        public IUserService UserService { get; }
        public IAuthService AuthService { get; }
    }
}
