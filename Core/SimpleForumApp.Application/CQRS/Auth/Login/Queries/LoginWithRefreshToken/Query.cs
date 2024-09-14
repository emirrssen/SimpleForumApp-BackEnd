using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Domain.DTOs.Auth.TokenDtos;

namespace SimpleForumApp.Application.CQRS.Auth.Login.Queries.LoginWithRefreshToken
{
    public class Query : QueryBase<Token>
    {
        public string RefreshToken { get; set; }
    }
}
