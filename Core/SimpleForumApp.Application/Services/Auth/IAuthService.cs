using SimpleForumApp.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Application.Services.Auth
{
    public interface IAuthService
    {
        Task<Result> LoginAsync(string email, string password);
    }
}
