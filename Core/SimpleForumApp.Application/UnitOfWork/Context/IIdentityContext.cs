﻿using SimpleForumApp.Application.Services.Auth;
using SimpleForumApp.Application.UnitOfWork.Core;

namespace SimpleForumApp.Application.UnitOfWork.Context
{
    public interface IIdentityContext : IInjectable
    {
        public IUserService UserService { get; }
        public IAuthService AuthService { get; }
        public ITokenService TokenService { get; }
    }
}
