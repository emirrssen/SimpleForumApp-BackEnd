using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.Commands.UpdateById
{
    public class Handler : CommandHandlerBase<Command>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _unitOfWork.Context.Identity.UserService.GetByIdAsync(request.Id);

            if (userToUpdate is null)
                return ResultFactory.FailResult("Kullanıcı bulunamadı");

            var personToUpdate = await _unitOfWork.Context.App.PersonRepository.GetByIdAsync(userToUpdate.PersonId);

            if (personToUpdate is null)
                return ResultFactory.FailResult("Kullanıcı bulunamadı");

            await _unitOfWork.Database.EfCoreDb.BeginTransactionAsync();

            if (
                personToUpdate.FirstName != request.FirstName ||
                personToUpdate.LastName != request.LastName ||
                personToUpdate.StatusId != request.StatusId || 
                personToUpdate.CountryId != request.CountryId ||
                personToUpdate.GenderId != request.GenderId ||
                personToUpdate.DateOfBirth != request.DateOfBirth
            )
            {
                await _unitOfWork.Context.App.PersonRepository.UpdateByIdAsync(new()
                {
                    Id = userToUpdate.PersonId,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    StatusId = request.StatusId,
                    CountryId = request.CountryId,
                    GenderId = request.GenderId,
                    DateOfBirth = request.DateOfBirth
                });
            }

            await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
            return ResultFactory.SuccessResult("Güncelleme işlemi başarılı");
        }
    }
}
