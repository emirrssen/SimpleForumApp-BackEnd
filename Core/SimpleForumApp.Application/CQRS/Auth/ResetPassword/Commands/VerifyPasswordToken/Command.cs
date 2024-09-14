﻿using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;

namespace SimpleForumApp.Application.CQRS.Auth.ResetPassword.Commands.VerifyPasswordToken
{
    public class Command : CommandBase
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
