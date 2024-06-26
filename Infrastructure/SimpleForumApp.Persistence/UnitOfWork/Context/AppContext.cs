﻿using SimpleForumApp.Application.Repositories.PersonRepositories;
using SimpleForumApp.Application.UnitOfWork.Context;
using SimpleForumApp.Persistence.UnitOfWork.Core;

namespace SimpleForumApp.Persistence.UnitOfWork.Context
{
    public class AppContext : ServiceGetter, IAppContext
    {
        public AppContext(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public IPersonWriteRepository PersonRepository => GetService<IPersonWriteRepository>();
    }
}
