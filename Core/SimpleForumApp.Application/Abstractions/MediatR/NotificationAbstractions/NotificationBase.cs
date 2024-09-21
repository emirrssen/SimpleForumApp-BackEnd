using MediatR;
using SimpleForumApp.Application.BaseStructures.MediatR;

namespace SimpleForumApp.Application.Abstractions.MediatR.NotificationAbstractions
{
    public abstract class NotificationBase : INotification, IMediatrAbstractionCore { }
}
