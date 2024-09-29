using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.RoleMatchingManagement.Queries.GetRolesToSelect
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
            var result = await _unitOfWork.Context.Auth.RoleRepository.GetAllDetailsByStatusAsync(1);

            if (!result.Any())
                return ResultFactory.WarningResult<IList<Response>>("Sistemde kayıtlı rol bulunamadı");

            var currentMatchings = await _unitOfWork.Context.Auth.UserRoleRepository.GetByUserIdAsync(request.UserId);

            List<Response> resultToReturn = new();

            result.ToList().ForEach(x =>
            {
                if (!currentMatchings.Any(y => y.RoleId == x.Id && y.StatusId != 3))
                {
                    resultToReturn.Add(new()
                    {
                        Id = x.Id,
                        Name = x.Name
                    });
                }
            });

            return ResultFactory.SuccessResult<IList<Response>>(resultToReturn);
        }
    }
}
