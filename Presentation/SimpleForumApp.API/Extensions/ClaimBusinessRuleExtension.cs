using SimpleForumApp.API.ClaimBusinessRules;
using SimpleForumApp.API.ClaimBusinessRules.Abstraction;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Entities.Auth;
using System.Reflection;

namespace SimpleForumApp.API.Extensions
{
    public static class ClaimBusinessRuleExtension
    {
        public static async Task GenerateClaimBusinessRules(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var unitOfWork = serviceProvider.GetService<IUnitOfWork>();

            await unitOfWork!.Database.EfCoreDb.BeginTransactionAsync();

            var insertedClaimBusinessRules = await unitOfWork.Context.Auth.ClaimBusinessRuleRepository.GetAllAsync();
            var currentClaimBusinessRules = GetClaimBusinessRulesInfo();

            List<ClaimBusinessRule> claimBusinessRulesToInsert = currentClaimBusinessRules.Where(x => !insertedClaimBusinessRules.Any(y => y.Code == x.Code)).ToList();
            List<ClaimBusinessRule> claimBusinessRulesToNotUse = insertedClaimBusinessRules.Where(x => !currentClaimBusinessRules.Any(y => y.Code == x.Code)).ToList();
            List<ClaimBusinessRule> claimBusinessRulesToUse = insertedClaimBusinessRules.Where(x => currentClaimBusinessRules.Any(y => y.Code == x.Code) && x.StatusId == 2).ToList();

            claimBusinessRulesToNotUse.ForEach(x =>
            {
                x.StatusId = 2;
                x.UpdatedDate = DateTime.Now;
            });

            claimBusinessRulesToUse.ForEach(x =>
            {
                x.StatusId = 1;
                x.UpdatedDate = DateTime.Now;
            });

            claimBusinessRulesToInsert.ForEach(x =>
            {
                x.StatusId = 1;
                x.CreatedDate = DateTime.Now;
            });

            claimBusinessRulesToNotUse.AddRange(claimBusinessRulesToUse);

            await unitOfWork.Context.Auth.ClaimBusinessRuleRepository.BulkInsertAsync(claimBusinessRulesToInsert);
            await unitOfWork.Context.Auth.ClaimBusinessRuleRepository.BulkUpdateAsync(claimBusinessRulesToNotUse);

            await unitOfWork.Database.EfCoreDb.CommitTransactionAsync();

            claimBusinessRulesToInsert.ForEach(x => Console.WriteLine($"{DateTime.Now} | {x.Code} inserted."));
            claimBusinessRulesToNotUse.ForEach(x => Console.WriteLine($"{DateTime.Now} | {x.Code} is found in database but it's not currently active. Therefor StatusId property set to 1."));
            claimBusinessRulesToUse.ForEach(x => Console.WriteLine($"{DateTime.Now} | {x.Code} not found in database. Therefor StatusId property set to 2."));
        }

        private static IList<ClaimBusinessRule> GetClaimBusinessRulesInfo()
        {
            List<ClaimBusinessRule> claimBusinessRulesInfo = new();

            var assembly = Assembly.GetExecutingAssembly();
            var claimBusinessRules = assembly.GetTypes().Where(x => x.IsAssignableTo(typeof(IClaimBusinessRule)) && !x.IsAbstract).ToList();

            foreach (var claimBusinessRule in claimBusinessRules)
            {
                var currentRule = (ClaimBusinessRuleBase)Activator.CreateInstance(claimBusinessRule)!;

                if (currentRule.ExecutionOrder == ExecutionOrder.None || currentRule.Priority == 0 || string.IsNullOrEmpty(currentRule.Code))
                    continue;

                claimBusinessRulesInfo.Add(new()
                {
                    Code = currentRule.Code,
                    ExecutionOrderId = (int)currentRule.ExecutionOrder,
                    Priority = currentRule.Priority
                });
            }

            return claimBusinessRulesInfo;
        }
    }
}
