using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionManagement.Commands.UpdateById
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
            var permissions = await _unitOfWork.Context.Auth.PermissionRepository.GetAllAsync();
            var permissionToUpdate = permissions.FirstOrDefault(x => x.Id == request.Id);

            if (permissionToUpdate == null)
                return ResultFactory.FailResult("Yetki bulunamadı");

            if (
                permissionToUpdate.Name.ToLower().Replace(" ", "") != request.Name.ToLower().Replace(" ", "")
                && permissions.Any(x => x.Name.ToLower().Replace(" ", "") == request.Name.ToLower().Replace(" ", ""))
            )
            {
                return ResultFactory.FailResult("Aynı isme sahip bir yetki sistemde zaten tanımlı");
            }

            if (request.StatusId != 1)
            {
                var permissionsToUsedByEndPoints = await _unitOfWork.Context.Auth.EndPointPermissionRepository.GetByPermissionIdAsync(request.Id);

                if (permissionsToUsedByEndPoints.Any())
                    return ResultFactory.FailResult("Bu yetki, end point eşleşmelerinde kullanılmaktadır");

                var permissionToUsedByRoles = await _unitOfWork.Context.Auth.RolePermissionRepository.GetByPermissionIdAsync(request.Id);

                if (permissionToUsedByRoles.Any())
                    return ResultFactory.FailResult("Bu yetki, rol eşleşmelerinde kullanılmaktadır");                
            }

            await _unitOfWork.Database.EfCoreDb.BeginTransactionAsync();

            await _unitOfWork.Context.Auth.PermissionRepository.UpdateAsync(new()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                StatusId = request.StatusId,
                UpdatedDate = DateTime.UtcNow,
                CreatedDate = permissionToUpdate.CreatedDate
            });

            await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
            return ResultFactory.SuccessResult("Güncelleme başarılı");
        }
    }
}
