using SimpleForumApp.Application.UnitOfWork;

namespace SimpleForumApp.API.Extensions
{
    public static class ClaimBusinessRuleExtension
    {
        public static async Task GenerateClaimBusinessRules(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var unitOfWork = serviceProvider.GetService<IUnitOfWork>();

            await unitOfWork!.Database.EfCoreDb.BeginTransactionAsync();


        }
    }
}
