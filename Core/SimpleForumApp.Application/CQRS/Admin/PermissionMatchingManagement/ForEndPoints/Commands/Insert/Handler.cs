using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForEndPoints.Commands.Insert
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
            var currentPermissionMatchings = await _unitOfWork.Context.Auth.EndPointPermissionRepository.GetAllPermissionsByEndPointAsync(request.EndPointId);

            if (currentPermissionMatchings.Any(x => x.PermissionId == request.PermissionId && x.StatusId != 3))
                return ResultFactory.FailResult("Eklemek istediğiniz eşleşme zaten mevcut");

            await _unitOfWork.Database.EfCoreDb.BeginTransactionAsync();

            var currentPermissionMatch = await _unitOfWork.Context.Auth.EndPointPermissionRepository.GetByEndPointAndPermissionIdAsync(request.EndPointId, request.PermissionId);

            if (currentPermissionMatch != null && currentPermissionMatch.StatusId == 3)
            {
                currentPermissionMatch.StatusId = 1;
                currentPermissionMatch.UpdatedDate = DateTime.Now;

                await _unitOfWork.Context.Auth.EndPointPermissionRepository.UpdateAsync(currentPermissionMatch);

                await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
                return ResultFactory.SuccessResult("Ekleme işlemi başarılı");
            }

            var insertResult = await _unitOfWork.Context.Auth.EndPointPermissionRepository.InsertAsync(new()
            {
                CreatedDate = DateTime.Now,
                EndPointId = request.EndPointId,
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
