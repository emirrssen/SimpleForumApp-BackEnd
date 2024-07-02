﻿using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.Entities.App;

namespace SimpleForumApp.Application.Repositories.PersonRepositories
{
    public interface IPersonWriteRepository : IInjectable
    {
        Task<long> InsertAsync(Person person);
        Task<bool> DeleteByIdAsync(long id);
    }
}
