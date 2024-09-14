using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Auth.ForgotMyPassword.Queries.SendMailForPasswordReset
{
    public class Query : QueryBase<string>
    {
        public string Email { get; set; }
    }
}
