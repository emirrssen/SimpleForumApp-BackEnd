using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Auth.Commands.Register
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
            var personInsertResult = await _unitOfWork.PersonRepository.InsertAsync(new()
            {
                CountryId = request.CountryId,
                StatusId = 1,
                GenderId = request.GenderId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                CreatedDate = DateTime.Now
            });

            if (personInsertResult <= 0)
            {
                return ResultFactory.FailResult("Kayıt olma işlemi başarısız");
            }

            var userInsertResult = await _unitOfWork.UserService.InsertAsync(new()
            {
                PersonId = personInsertResult,
                UserName = request.UserName,
                Email = request.EmailAddress,
                PhoneNumber = request.PhoneNumber
            }, request.Password);

            if (!userInsertResult.IsSuccess)
            {
                await _unitOfWork.PersonRepository.DeleteByIdAsync(personInsertResult);

                return ResultFactory.FailResult(userInsertResult.Message);
            }

            return ResultFactory.SuccessResult("Kayıt olma işlemi başarılı");
        }
    }
}
