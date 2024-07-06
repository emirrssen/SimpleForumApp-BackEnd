using Microsoft.AspNetCore.Mvc.Filters;
using SimpleForumApp.Application.Helpers;
using SimpleForumApp.Application.UnitOfWork;

namespace SimpleForumApp.API.Filters
{
    public class CalculateEndPointExecutionTimeFilter : ActionFilterAttribute
    {
        private DateTime _startDate;
        private readonly IUnitOfWork _unitOfWork;

        public CalculateEndPointExecutionTimeFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _startDate = DateTime.Now;

            await next.Invoke();

            var endDate = DateTime.Now;
            var contextActionType = context.HttpContext.Request.Method;
            var endPointActionType = ActionTypeConverterHelper.ConvertActionType(contextActionType);
            var endPointRoute = context.HttpContext.Request.Path.Value;

            await _unitOfWork.Database.EfCoreDb.BeginTransactionAsync();

            var endPoint = await _unitOfWork.Context.Traceability.EndPointRepository.GetByRouteAndActionTypeId(endPointRoute.Substring(1), endPointActionType);
            var endPointActivityInsertResult = await _unitOfWork.Context.Traceability.EndPointActivityRepository.InsertAsync(new()
            {
                ActivityStartDate = _startDate,
                ActivityEndDate = endDate,
                EndPointId = endPoint.Id,
            });

            if (endPointActivityInsertResult <= 0)
                await _unitOfWork.Database.EfCoreDb.RollbackTransactionAsync();

            await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
        }
    }
}
