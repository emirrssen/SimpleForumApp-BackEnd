using SimpleForumApp.Domain.DTOs.Auth;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.Services.Auth
{
    public interface IAuthService
    {
        Task<ResultWithData<Token>> LoginAsync(string email, string password);
        Task<ResultWithData<Token>> LoginWithRefreshTokenAsync(string refreshToken);
        Task<Result> CreateResetPasswordLinkAsync(string email);
        Task<Result> ResetPasswordAsync(long id, string token, string password);
    }
}
