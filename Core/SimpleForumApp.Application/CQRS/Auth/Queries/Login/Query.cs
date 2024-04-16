using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Domain.DTOs.Auth;

namespace SimpleForumApp.Application.CQRS.Auth.Queries.Login
{
    public class Query : QueryBase<Token>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
