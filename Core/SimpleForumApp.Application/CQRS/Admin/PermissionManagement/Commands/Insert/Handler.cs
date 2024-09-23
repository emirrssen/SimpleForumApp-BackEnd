using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionManagement.Commands.Insert
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
            var permissions = await _unitOfWork.Context.Auth.PermissionRepository.GetAllAsync();

            if (permissions.Any(x => x.Name.ToLower().Replace(" ", "") == request.Name.ToLower().Replace(" ", "")))
                return ResultFactory.FailResult("Aynı isme sahip bir yetki zaten sistemde tanımlı");

            await _unitOfWork.Database.EfCoreDb.BeginTransactionAsync();

            var result = await _unitOfWork.Context.Auth.PermissionRepository.InsertAsync(new()
            {
                CreatedDate = DateTime.Now,
                Description = request.Description,
                Name = request.Name,
                StatusId = request.StatusId
            });

            if (result <= 0)
            {
                await _unitOfWork.Database.EfCoreDb.RollbackTransactionAsync();
                return ResultFactory.FailResult("Ekleme işlemi başarısız");
            }

            await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
            return ResultFactory.SuccessResult("Ekleme işlemi başarılı");
        }
    }
}
