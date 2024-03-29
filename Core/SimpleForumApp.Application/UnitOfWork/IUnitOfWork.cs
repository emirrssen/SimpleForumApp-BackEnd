using SimpleForumApp.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IStatusRepository StatusRepository { get; }
        public IGenderRepository GenderRepository { get; }
    }
}
