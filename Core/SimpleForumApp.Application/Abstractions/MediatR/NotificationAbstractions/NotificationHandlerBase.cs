using MediatR;

namespace SimpleForumApp.Application.Abstractions.MediatR.NotificationAbstractions
{
    public abstract class NotificationHandlerBase<TNotificaiton> : NotificationHandler<TNotificaiton> where TNotificaiton : NotificationBase
    {
    }
}
