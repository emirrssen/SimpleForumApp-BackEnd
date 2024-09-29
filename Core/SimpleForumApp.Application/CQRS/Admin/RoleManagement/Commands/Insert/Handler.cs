using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.RoleManagement.Commands.Insert
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
            var roles = await _unitOfWork.Context.Auth.RoleRepository.GetAllAsync();

            if (roles.Any(x => x.Name.ToLower().Replace(" ", "") == request.Name.ToLower().Replace(" ", "")))
                return ResultFactory.WarningResult("Aynı isme sahip bir rol sistemde zaten mevcut");

            await _unitOfWork.Database.EfCoreDb.BeginTransactionAsync();

            var insertResult = await _unitOfWork.Context.Auth.RoleRepository.InsertAsync(new()
            {
                Name = request.Name,
                Description = request.Description,
                StatusId = request.StatusId,
                CreatedDate = DateTime.UtcNow
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
