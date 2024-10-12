using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForEndPoints.Commands.Insert
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
            var currentPermissionMatchings = await _unitOfWork.Context.Auth.EndPointPermissionRepository.GetAllPermissionsByEndPointAsync(request.EndPointId);

            if (currentPermissionMatchings.Any(x => x.PermissionId == request.PermissionId && x.StatusId != 3))
                return ResultFactory.FailResult("Eklemek istediğiniz eşleşme zaten mevcut");

            await _unitOfWork.Database.EfCoreDb.BeginTransactionAsync();

            var currentPermissionMatch = await _unitOfWork.Context.Auth.EndPointPermissionRepository.GetByEndPointAndPermissionIdAsync(request.EndPointId, request.PermissionId);

            if (currentPermissionMatch != null && currentPermissionMatch.StatusId == 3)
            {
                currentPermissionMatch.StatusId = 1;
                currentPermissionMatch.UpdatedDate = DateTime.Now;

                await _unitOfWork.Context.Auth.EndPointPermissionRepository.UpdateAsync(currentPermissionMatch);

                await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
                return ResultFactory.SuccessResult("Ekleme işlemi başarılı");
            }

            var insertResult = await _unitOfWork.Context.Auth.EndPointPermissionRepository.InsertAsync(new()
            {
                CreatedDate = DateTime.Now,
                EndPointId = request.EndPointId,
                PermissionId = request.PermissionId,
                StatusId = 1
            });

            if (insertResult <= 0)
            {
                await _unitOfWork.Database.EfCoreDb.RollbackTransactionAsync();
                return ResultFactory.FailResult("Ekleme işlemi başarısız");
            }

            var endPoint = await _unitOfWork.Context.Traceability.EndPointRepository.GetByIdAsync(request.EndPointId);
            var permissionsForEndPoint = await _unitOfWork.Context.Auth.EndPointPermissionRepository.GetAllPermissionsByEndPointAsync(request.EndPointId);

            string key = $"{endPoint.Id}, {endPoint.ActionTypeId}, {endPoint.MethodName}, {endPoint.EndPointRoute}";
            string value = string.Join(", ", permissionsForEndPoint.Select(x => x.PermissionId.ToString()));

            var isExists = await _unitOfWork.Context.Cache.RedisCacheService.GetAsync(key);

            if (isExists != null)
                await _unitOfWork.Context.Cache.RedisCacheService.RemoveAsync(key);

            var result = await _unitOfWork.Context.Cache.RedisCacheService.SetAsync(key, value, 10080, 86400);
            Console.WriteLine($"[{DateTime.Now}] Endpoint with {key} key added with {value} values.");

            await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
            return ResultFactory.SuccessResult("Ekleme işlemi başarılı");
        }
    }
}
