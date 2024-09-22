using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.EndPointManagement.Commands.UpdateById
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
            var endPointToUpdate = await _unitOfWork.Context.Traceability.EndPointRepository.GetByIdAsync(request.Id);

            if (endPointToUpdate is null)
                return ResultFactory.FailResult("End point bulunamadı");

            endPointToUpdate.IsActive = request.IsActive;
            endPointToUpdate.IsUse = request.IsUse;
            endPointToUpdate.Description = request.Description;

            await _unitOfWork.Database.EfCoreDb.BeginTransactionAsync();

            await _unitOfWork.Context.Traceability.EndPointRepository.UpdateEndPoint(endPointToUpdate);

            await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
            return ResultFactory.SuccessResult("Güncelleme işlemi başarılı");
        }
    }
}
