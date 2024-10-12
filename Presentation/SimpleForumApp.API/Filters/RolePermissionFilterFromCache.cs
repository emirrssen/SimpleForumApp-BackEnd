using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SimpleForumApp.Application.Helpers;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Persistence.UnitOfWork;

namespace SimpleForumApp.API.Filters
{
    public class RolePermissionFilterFromCache : IAsyncActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;

        public RolePermissionFilterFromCache(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userName = context.HttpContext.User.Identity?.Name;

            if (!string.IsNullOrEmpty(userName) )
            {
                var contextActionType = context.HttpContext.Request.Method;
                var endPointActionType = ActionTypeConverterHelper.ConvertActionType(contextActionType);
                var endPointRoute = context.HttpContext.Request.Path.Value;

                var endPoint = await _unitOfWork.Context.Traceability.EndPointRepository.GetByRouteAndActionTypeId(endPointRoute.Substring(1), endPointActionType);

                if (!endPoint.IsActive)
                {
                    context.Result = new NotFoundResult();
                    return;
                }

                if (!endPoint.IsUse)
                {
                    context.Result = new StatusCodeResult(503);
                    return;
                }

                var permissionsOfEndPoint = await _unitOfWork.Context.Cache.RedisCacheService.GetAsync($"{endPoint.Id}, {endPoint.ActionTypeId}, {endPoint.MethodName}, {endPoint.EndPointRoute}");

                if (string.IsNullOrEmpty(permissionsOfEndPoint))
                {
                    var permissionsForEndPoint = await _unitOfWork.Context.Auth.EndPointPermissionRepository.GetAllPermissionsByEndPointAsync(endPoint.Id);

                    if (!permissionsForEndPoint.Any())
                    {
                        await next.Invoke();
                        return;
                    }

                    string key = $"{endPoint.Id}, {endPoint.ActionTypeId}, {endPoint.MethodName}, {endPoint.EndPointRoute}";
                    string value = string.Join(", ", permissionsForEndPoint.Select(x => x.PermissionId.ToString()));

                    var isExists = await _unitOfWork.Context.Cache.RedisCacheService.GetAsync(key);

                    if (isExists != null)
                        await _unitOfWork.Context.Cache.RedisCacheService.RemoveAsync(key);

                    var result = await _unitOfWork.Context.Cache.RedisCacheService.SetAsync(key, value, 10080, 86400);
                    Console.WriteLine($"[{DateTime.Now}] Endpoint with {key} key added with {value} values.");

                    permissionsOfEndPoint = await _unitOfWork.Context.Cache.RedisCacheService.GetAsync($"{endPoint.Id}, {endPoint.ActionTypeId}, {endPoint.MethodName}, {endPoint.EndPointRoute}");
                }

                var permissionsOfUser = await _unitOfWork.Context.Cache.RedisCacheService.GetAsync(userName);

                if (string.IsNullOrEmpty(permissionsOfUser))
                {
                    var permissionsForUser = await _unitOfWork.Context.Auth.UserRoleRepository.GetAllUserPermissionsByUserNameAsync(userName);

                    if (!permissionsForUser.Any())
                    {
                        context.Result = new UnauthorizedResult();
                        return;
                    }

                    string key = userName;
                    string value = string.Join(", ", permissionsForUser);

                    var isExists = await _unitOfWork.Context.Cache.RedisCacheService.GetAsync(key);

                    if (isExists != null)
                        await _unitOfWork.Context.Cache.RedisCacheService.RemoveAsync(key);

                    var result = await _unitOfWork.Context.Cache.RedisCacheService.SetAsync(key, value, 10080, 86400);
                    Console.WriteLine($"[{DateTime.Now}] User with {key} key added with {value} values.");

                    permissionsOfUser = await _unitOfWork.Context.Cache.RedisCacheService.GetAsync(userName);
                }

                var endPointsPermissions = permissionsOfEndPoint.Split(", ").ToArray();
                var userPermissions = permissionsOfUser.Split(", ").ToArray();

                if (!userPermissions.Any(x => endPointsPermissions.Any(y => y == x)))
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            }

            await next.Invoke();
        }
    }
}
