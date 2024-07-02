using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.PersonManagement.Queries.GetAllPersonDetails
{
    public class Handler : QueryHandlerBase<Query, IList<Dto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<ResultWithData<IList<Dto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Context.App.PersonReadRepository.GetAllPersonDetailsAsync();

            if (!result.Any())
                return ResultFactory.SuccessResult<IList<Dto>>("Herhangi bir kişi kaydı bulunamadı");

            return ResultFactory.SuccessResult<IList<Dto>>(result.Select(x => new Dto
            {
                Id = x.Id,
                CountryId = x.CountryId,
                GenderId = x.GenderId,
                GenderName = x.GenderName,
                CountryName = x.CountryName,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateOfBirth = x.DateOfBirth,
                ProfileImage = x.ProfileImage,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
            }).ToList());
        }
    }
}
