using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForRoles.Commands.BulkUpdate
{
    public class Handler : CommandHandlerBase<Command>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Database.EfCoreDb.BeginTransactionAsync();

            foreach (var item in request.ItemsToUpdate)
            {
                var currentItemToUpdate = await _unitOfWork.Context.Auth.RolePermissionRepository.GetByRoleAndPermissionIdAsync(item.RoleId, item.PermissionId);

                if (currentItemToUpdate == null)
                    continue;

                if (currentItemToUpdate!.StatusId == item.StatusId)
                    continue;

                currentItemToUpdate.StatusId = item.StatusId;
                currentItemToUpdate.UpdatedDate = DateTime.Now;

                await _unitOfWork.Context.Auth.RolePermissionRepository.UpdateAsync(currentItemToUpdate);
            }

            await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();

            var users = await _unitOfWork!.Context.Identity.UserService.GetAllAsync();

            foreach (var user in users)
            {
                var permissionsForUser = await _unitOfWork.Context.Auth.UserRoleRepository.GetAllUserPermissionsByUserIdAsync(user.Id);

                string key = user.UserName;
                string value = string.Join(", ", permissionsForUser);

                var isExists = await _unitOfWork.Context.Cache.RedisCacheService.GetAsync(key);

                if (isExists != null)
                    await _unitOfWork.Context.Cache.RedisCacheService.RemoveAsync(key);

                var result = await _unitOfWork.Context.Cache.RedisCacheService.SetAsync(key, value, 10080, 86400);
                Console.WriteLine($"[{DateTime.Now}] User with {key} key added with {value} values.");
            }

            return ResultFactory.SuccessResult("Güncelleme işlemi başarılı");
        }
    }
}
