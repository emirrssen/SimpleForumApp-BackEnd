using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.PersonManagement.Queries.GetAllPersonDetails
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
            var result = await _unitOfWork.Context.App.PersonRepository.GetAllPersonDetailsAsync();

            if (!result.Any())
                return ResultFactory.SuccessResult<IList<Response>>("Herhangi bir kişi kaydı bulunamadı");

            return ResultFactory.SuccessResult<IList<Response>>(result.Select(x => new Response
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
