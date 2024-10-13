using Microsoft.EntityFrameworkCore.Diagnostics;
using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;
using static System.Net.Mime.MediaTypeNames;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForEndPoints.Commands.BulkUpdate
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
            await _unitOfWork.Database.EfCoreDb.BeginTransactionAsync();

            foreach (var item in request.ItemsToUpdate)
            {
                var currentItemToUpdate = await _unitOfWork.Context.Auth.EndPointPermissionRepository.GetByEndPointAndPermissionIdAsync(item.EndPointId, item.PermissionId);

                if (currentItemToUpdate == null)
                    continue;

                if (currentItemToUpdate!.StatusId == item.StatusId)
                    continue;

                currentItemToUpdate.StatusId = item.StatusId;
                currentItemToUpdate.UpdatedDate = DateTime.Now;

                await _unitOfWork.Context.Auth.EndPointPermissionRepository.UpdateAsync(currentItemToUpdate);
            }

            await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();

            foreach(var item in request.ItemsToUpdate.Select(x => x.EndPointId))
            {
                var endPoint = await _unitOfWork.Context.Traceability.EndPointRepository.GetByIdAsync(item);
                var permissionsForEndPoint = await _unitOfWork.Context.Auth.EndPointPermissionRepository.GetAllPermissionsByEndPointAsync(item);

                string key = $"{endPoint.Id}, {endPoint.ActionTypeId}, {endPoint.MethodName}, {endPoint.EndPointRoute}";
                string value = string.Join(", ", permissionsForEndPoint.Select(x => x.PermissionId.ToString()));

                var isExists = await _unitOfWork.Context.Cache.RedisCacheService.GetAsync(key);

                if (isExists != null)
                    await _unitOfWork.Context.Cache.RedisCacheService.RemoveAsync(key);

                var result = await _unitOfWork.Context.Cache.RedisCacheService.SetAsync(key, value, 10080, 86400);
                Console.WriteLine($"[{DateTime.Now}] Endpoint with {key} key added with {value} values.");
            }


            return ResultFactory.SuccessResult("Güncelleme işlemi başarılı");
        }
    }
}
