using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.RoleManagement.Commands.UpdateById
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
            var roleToUpdate = roles.FirstOrDefault(x => x.Id == request.Id);

            if (roleToUpdate is null)
                return ResultFactory.FailResult("Rol bulunamadı");

            if (roleToUpdate.Name != request.Name && roles.Any(x => x.Name == request.Name))
                return ResultFactory.FailResult("Aynı isme sahip bir rol sistemde zaten tanımlı");

            await _unitOfWork.Database.EfCoreDb.BeginTransactionAsync();

            await _unitOfWork.Context.Auth.RoleRepository.UpdateAsync(new()
            {
                UpdatedDate = DateTime.Now,
                Name = request.Name,
                Description = request.Description,
                Id = request.Id,
                StatusId = request.StatusId
            });

            await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
            return ResultFactory.SuccessResult("Güncelleme işlemi başarılı");
        }
    }
}
