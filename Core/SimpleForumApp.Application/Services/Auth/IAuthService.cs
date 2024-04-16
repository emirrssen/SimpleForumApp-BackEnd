using SimpleForumApp.Domain.DTOs.Auth;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.Services.Auth
{
    public interface IAuthService
    {
        Task<ResultWithData<Token>> LoginAsync(string email, string password);
    }
}
