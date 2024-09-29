using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.RoleMatchingManagement.Commands.Insert
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

            await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
            return ResultFactory.SuccessResult("Ekleme işlemi başarılı");
        }
    }
}
