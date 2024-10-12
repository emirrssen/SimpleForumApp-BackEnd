using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.RoleMatchingManagement.Commands.BulkUpdate
{
    public class Handler : CommandHandlerBase<Command>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Handler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async override Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;

            await _unitOfWork.Database.EfCoreDb.BeginTransactionAsync();

            foreach (var item in request.ItemsToUpdate)
            {
                var currentItemToUpdate = await _unitOfWork.Context.Auth.UserRoleRepository.GetByUserIdAndRoleIdAsync(item.UserId, item.RoleId);

                if (currentItemToUpdate == null)
                    continue;

                if (currentItemToUpdate!.StatusId == item.StatusId)
                    continue;

                currentItemToUpdate.StatusId = item.StatusId;
                currentItemToUpdate.UpdatedDate = DateTime.Now;

                await _unitOfWork.Context.Auth.UserRoleRepository.UpdateAsync(currentItemToUpdate);

                var permissionsForUser = await _unitOfWork.Context.Auth.UserRoleRepository.GetAllUserPermissionsByUserNameAsync(userName);

                string key = userName;
                string value = string.Join(", ", permissionsForUser);

                var isExists = await _unitOfWork.Context.Cache.RedisCacheService.GetAsync(key);

                if (isExists != null)
                    await _unitOfWork.Context.Cache.RedisCacheService.RemoveAsync(key);

                var result = await _unitOfWork.Context.Cache.RedisCacheService.SetAsync(key, value, 10080, 86400);
                Console.WriteLine($"[{DateTime.Now}] User with {key} key added with {value} values.");
            }

            await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
            return ResultFactory.SuccessResult("Güncelleme işlemi başarılı");
        }
    }
}
