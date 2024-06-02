using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;

namespace SimpleForumApp.Application.CQRS.Auth.Commands.ResetPassword
{
    public class Command : CommandBase
    {
        public long UserId { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
