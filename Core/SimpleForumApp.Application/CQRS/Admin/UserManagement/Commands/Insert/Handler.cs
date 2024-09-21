using MediatR;
using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.Commands.Insert
{
    public class Handler : CommandHandlerBase<Command>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public Handler(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public override async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            using var transaction = _unitOfWork.Database.EfCoreDb.BeginTransactionAsync();

            var personInsertResult = await _unitOfWork.Context.App.PersonRepository.InsertAsync(new()
            {
                CountryId = request.CountryId,
                StatusId = request.StatusId,
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

            var generatedPassword = GenerateRandomPassword();

            var userInsertResult = await _unitOfWork.Context.Identity.UserService.InsertAsync(new()
            {
                PersonId = personInsertResult,
                UserName = request.UserName,
                Email = request.EmailAddress,
                PhoneNumber = FormatPhoneNumber(request.PhoneNumber)
            }, generatedPassword);

            if (!userInsertResult.IsSuccess)
            {
                await _unitOfWork.Database.EfCoreDb.RollbackTransactionAsync();
                return userInsertResult;
            }

            string subject = "Kayıt Sonrası Otomatik Atanan Şifreniz";
            string body = $@"
                <p>Değerli Simple Forum App Kullanıcısı,</p>
                <p>
                    Hesabınız başarılı bir şekilde oluşturulmuştur. 
                    Verilen e-posta ve şifre ile sisteme giriş yapabilirsiniz.
                </p>
                <p><b>E-Posta Adresi - </b>{request.EmailAddress}</p>
                <p><b>Şifre - </b>{generatedPassword}</p>
                <p>Saygılarımızla</p>
            ";

            try
            {
                await _unitOfWork.Context.Notification.EmailService.SendMailAsync(
                    subject, body, true, request.EmailAddress
                );
            }
            catch (Exception)
            {
                await _unitOfWork.Database.EfCoreDb.RollbackTransactionAsync();
                return ResultFactory.FailResult("Kayıt olma işlemi başarısız");
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

        private string GenerateRandomPassword()
        {
            const string lowerChars = "abcdefghijklmnopqrstuvwxyz";
            const string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            const string specialChars = "!@#$%^&*()_+-=[]{}|;:,.<>?";

            Random random = new Random();
            char[] chars = new char[8];

            chars[0] = lowerChars[random.Next(lowerChars.Length)];
            chars[1] = upperChars[random.Next(upperChars.Length)];
            chars[2] = numbers[random.Next(numbers.Length)];
            chars[3] = specialChars[random.Next(specialChars.Length)];

            string allChars = lowerChars + upperChars + numbers + specialChars;
            for (int i = 4; i < 8; i++)
            {
                chars[i] = allChars[random.Next(allChars.Length)];
            }

            return ShuffleString(new string(chars), random);
        }

        private string ShuffleString(string input, Random random)
        {
            char[] array = input.ToCharArray();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                char temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            return new string(array);
        }
    }
}
