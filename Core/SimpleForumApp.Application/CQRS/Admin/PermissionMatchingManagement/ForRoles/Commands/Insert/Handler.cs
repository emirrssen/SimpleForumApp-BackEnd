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

            var currentPermissionMatch = currentPermissionMatchings.FirstOrDefault(x => x.RoleId == request.RoleId && x.PermissionId == request.PermissionId);

            if (currentPermissionMatch != null && currentPermissionMatch.StatusId != 3)
            {
                currentPermissionMatch.StatusId = 1;
                currentPermissionMatch.UpdatedDate = DateTime.Now;

                await _unitOfWork.Context.Auth.RolePermissionRepository.UpdateAsync(currentPermissionMatch);

                await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
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
            return ResultFactory.SuccessResult("Ekleme işlemi başarılı");
        }
    }
}
