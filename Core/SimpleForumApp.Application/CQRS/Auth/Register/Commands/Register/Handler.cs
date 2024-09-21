using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Auth.Register.Commands.Register
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
            using var transaction = _unitOfWork.Database.EfCoreDb.BeginTransactionAsync();

            var personInsertResult = await _unitOfWork.Context.App.PersonRepository.InsertAsync(new()
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
                await _unitOfWork.Database.EfCoreDb.RollbackTransactionAsync();
                return ResultFactory.FailResult("Kayıt olma işlemi başarısız");
            }

            var userInsertResult = await _unitOfWork.Context.Identity.UserService.InsertAsync(new()
            {
                PersonId = personInsertResult,
                UserName = request.UserName,
                Email = request.EmailAddress,
                PhoneNumber = FormatPhoneNumber(request.PhoneNumber)
            }, request.Password);

            if (!userInsertResult.IsSuccess)
            {
                await _unitOfWork.Database.EfCoreDb.RollbackTransactionAsync();
                return userInsertResult;
            }

            await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
            return ResultFactory.SuccessResult("Kayıt olma işlemi başarılı");
        }

        private string FormatPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length != 11)
            {
                return "";
            }

            string part1 = phoneNumber.Substring(0, 4);
            string part2 = phoneNumber.Substring(4, 3);
            string part3 = phoneNumber.Substring(7, 4);

            return $"{part1} {part2} {part3}";
        }
    }
}
