using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForRoles.Commands.Insert
{
    public class Handler : CommandHandlerBase<Command>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            var currentPermissionMatchings = await _unitOfWork.Context.Auth.RolePermissionRepository.GetByRoleIdAsync(request.RoleId);

            if (currentPermissionMatchings.Any(x => x.PermissionId == request.PermissionId && x.StatusId != 3))
                return ResultFactory.FailResult("Eklemek istediğiniz eşleşme zaten mevcut");

            await _unitOfWork.Database.EfCoreDb.BeginTransactionAsync();

            var currentPermissionMatch = await _unitOfWork.Context.Auth.RolePermissionRepository.GetByRoleAndPermissionIdAsync(request.RoleId, request.PermissionId);

            if (currentPermissionMatch != null && currentPermissionMatch.StatusId == 3)
            {
                currentPermissionMatch.StatusId = 1;
                currentPermissionMatch.UpdatedDate = DateTime.Now;

                await _unitOfWork.Context.Auth.RolePermissionRepository.UpdateAsync(currentPermissionMatch);

                await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();

                await UpdatePermissions();

                return ResultFactory.SuccessResult("Ekleme işlemi başarılı");
            }

            var insertResult = await _unitOfWork.Context.Auth.RolePermissionRepository.InsertAsync(new()
            {
                CreatedDate = DateTime.Now,
                RoleId = request.RoleId,
                PermissionId = request.PermissionId,
                StatusId = 1
            });

            if (insertResult <= 0)
            {
                await _unitOfWork.Database.EfCoreDb.RollbackTransactionAsync();
                return ResultFactory.FailResult("Ekleme işlemi başarısız");
            }

            await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();

            await UpdatePermissions();

            return ResultFactory.SuccessResult("Ekleme işlemi başarılı");
        }

        public async Task UpdatePermissions()
        {
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
        }
    }
}
