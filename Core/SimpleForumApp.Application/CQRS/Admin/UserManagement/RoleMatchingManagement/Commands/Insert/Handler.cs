using Microsoft.AspNetCore.Http;
using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.RoleMatchingManagement.Commands.Insert
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

        public override async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;

            var currentRoleMatchings = await _unitOfWork.Context.Auth.UserRoleRepository.GetByUserIdAsync(request.UserId);

            if (currentRoleMatchings.Any(x => x.RoleId == request.RoleId && x.StatusId != 3))
                return ResultFactory.FailResult("Eklemek istediğiniz eşleşme zaten mevcut");

            await _unitOfWork.Database.EfCoreDb.BeginTransactionAsync();

            var currentRoleMatching = await _unitOfWork.Context.Auth.UserRoleRepository.GetByUserIdAndRoleIdAsync(request.UserId, request.RoleId);

            if (currentRoleMatching != null && currentRoleMatching.StatusId == 3)
            {
                currentRoleMatching.StatusId = 1;
                currentRoleMatching.UpdatedDate = DateTime.Now;

                await _unitOfWork.Context.Auth.UserRoleRepository.UpdateAsync(currentRoleMatching);

                await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
                return ResultFactory.SuccessResult("Ekleme işlemi başarılı");
            }

            var insertResult = await _unitOfWork.Context.Auth.UserRoleRepository.InsertAsync(new()
            {
                CreatedDate = DateTime.Now,
                RoleId = request.RoleId,
                UserId = request.UserId,
                StatusId = 1
            });

            if (insertResult <= 0)
            {
                await _unitOfWork.Database.EfCoreDb.RollbackTransactionAsync();
                return ResultFactory.FailResult("Ekleme işlemi başarısız");
            }

            var permissionsForUser = await _unitOfWork.Context.Auth.UserRoleRepository.GetAllUserPermissionsByUserNameAsync(userName);

            string key = userName;
            string value = string.Join(", ", permissionsForUser);

            var isExists = await _unitOfWork.Context.Cache.RedisCacheService.GetAsync(key);

            if (isExists != null)
                await _unitOfWork.Context.Cache.RedisCacheService.RemoveAsync(key);

            var result = await _unitOfWork.Context.Cache.RedisCacheService.SetAsync(key, value, 10080, 86400);
            Console.WriteLine($"[{DateTime.Now}] User with {key} key added with {value} values.");

            await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
            return ResultFactory.SuccessResult("Ekleme işlemi başarılı");
        }
    }
}
