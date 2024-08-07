﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SimpleForumApp.Application.Helpers;
using SimpleForumApp.Application.UnitOfWork;

namespace SimpleForumApp.API.Filters
{
    public class RolePermissionFilter : IAsyncActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;

        public RolePermissionFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userName = context.HttpContext.User.Identity?.Name;

            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _unitOfWork.Context.Identity.UserService.GetByUserNameAsync(userName);

                var contextActionType = context.HttpContext.Request.Method;
                var endPointActionType = ActionTypeConverterHelper.ConvertActionType(contextActionType);
                var endPointRoute = context.HttpContext.Request.Path.Value;

                var endPoint = await _unitOfWork.Context.Traceability.EndPointRepository.GetByRouteAndActionTypeId(endPointRoute.Substring(1), endPointActionType);
                var endPointPermissions = await _unitOfWork.Context.Auth.EndPointPermissionRepository.GetAllPermissionsByEndPointAsync(endPoint.Id);
                var userRolePermissions = await _unitOfWork.Context.Auth.UserRoleRepository.GetAllUserPermissionsByUserIdAsync(user.Id);

                if (!endPointPermissions.Any())
                {
                    await next.Invoke();
                    return;
                }

                if (!userRolePermissions.Any(x => endPointPermissions.Any(y => y.PermissionId == x)))
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
                    
            }

            await next.Invoke();
        }
    }
}
