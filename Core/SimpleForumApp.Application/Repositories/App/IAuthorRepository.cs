﻿using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.Entities.App;

namespace SimpleForumApp.Application.Repositories.App
{
    public interface IAuthorRepository : IInjectable
    {
        Task<Author?> GetByUserIdAsync(long userId);
        Task<long> InsertAsync(Author author);
    }
}