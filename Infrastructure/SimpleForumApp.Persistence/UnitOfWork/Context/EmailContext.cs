using SimpleForumApp.Application.Services.Email;
using SimpleForumApp.Application.UnitOfWork.Context;
using SimpleForumApp.Persistence.UnitOfWork.Core;

namespace SimpleForumApp.Persistence.UnitOfWork.Context
{
    public class EmailContext : ServiceGetter, IEmailContext
    {
        public EmailContext(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public IEmailService EmailService => GetService<IEmailService>();
    }
}
