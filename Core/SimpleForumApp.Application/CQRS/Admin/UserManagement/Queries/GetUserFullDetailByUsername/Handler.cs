using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.Queries.GetUserFullDetailByUsername
{
    public class Handler : QueryHandlerBase<Query, Response>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<ResultWithData<Response>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Context.Identity.UserService.GetUserFullDetailByUserNameAsync(request.UserName);

            if (result == null)
                return ResultFactory.WarningResult<Response>("Kullanıcı bulunamadı");

            return ResultFactory.SuccessResult<Response>(new Response
            {
                Id = result.Id,
                UserName = request.UserName,
                CountryId = result.CountryId,
                DateOfBirth = result.DateOfBirth.ToString("yyyy-MM-dd"),
                Email = result.Email,
                FirstName = result.FirstName,
                LastName = result.LastName,
                GenderId = result.GenderId,
                PhoneNumber = result.PhoneNumber.Replace(" ", ""),
                ProfileImage = result.ProfileImage,
                StatusId = result.StatusId
            });
        }
    }
}
