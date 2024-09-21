using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.Queries.GetAllUserForList
{
    public class Handler : QueryHandlerBase<Query, IList<Response>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<ResultWithData<IList<Response>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Context.Identity.UserService.GetAllUsersForListAsync(request.IsPassiveShown);

            if (!result.Any())
                return ResultFactory.WarningResult<IList<Response>>("Sistemde kayıtlı kullanıcı bulunamadı");

            return ResultFactory.SuccessResult<IList<Response>>(result.Select(x => new Response
            {
                CountryName = x.CountryName,
                StatusName = x.StatusName,
                DateOfBirth = x.DateOfBirth.ToString("dd.MM.yyyy"),
                FirstName = x.FirstName,
                GenderName = x.GenderName,
                LastName = x.LastName,
                UserName = x.Username
            }).ToList());
        }
    }
}
