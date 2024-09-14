using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.IdentityModel.Tokens;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Entities.Traceability;
using SimpleForumApp.Domain.Enums;
using System.Reflection;

namespace SimpleForumApp.API.Extensions
{
    public static class EndPointRoleManagementExtensions
    {
        public async static Task GenerateEndPoints(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var unitOfWork = serviceProvider.GetService<IUnitOfWork>();

            await unitOfWork!.Database.EfCoreDb.BeginTransactionAsync();

            var insertedEndPoints = await unitOfWork.Context.Traceability.EndPointRepository.GetAllAsync();
            var currentEndPoints = ReadEndPoints();

            List<EndPoint> endPointsToInsert = currentEndPoints.Where(x => !insertedEndPoints.Any(y => y.EndPointRoute == x.EndPointRoute && y.ActionTypeId == x.ActionTypeId)).ToList();
            List<EndPoint> endPointsToNotUse = insertedEndPoints.Where(x => !currentEndPoints.Any(y => y.EndPointRoute == x.EndPointRoute && y.ActionTypeId == x.ActionTypeId)).ToList();
            List<EndPoint> endPointsToUse = insertedEndPoints.Where(x => currentEndPoints.Any(y => y.EndPointRoute == x.EndPointRoute && y.ActionTypeId == x.ActionTypeId && !x.IsUse)).ToList();

            endPointsToNotUse.ForEach(x => x.IsUse = false);
            endPointsToUse.ForEach(x => x.IsUse = true);

            endPointsToNotUse.AddRange(endPointsToUse);

            await unitOfWork.Context.Traceability.EndPointRepository.BulkInsertAsync(endPointsToInsert);
            await unitOfWork.Context.Traceability.EndPointRepository.BulkUpdateAsync(endPointsToNotUse);

            await unitOfWork.Database.EfCoreDb.CommitTransactionAsync();

            endPointsToInsert.ForEach(x => Console.WriteLine($"{DateTime.Now} | {x.EndPointRoute} inserted."));
            endPointsToUse.ForEach(x => Console.WriteLine($"{DateTime.Now} | {x.EndPointRoute} is found in database but it's not currently active. Therefor IsUse property set to true."));
            endPointsToNotUse.ForEach(x => Console.WriteLine($"{DateTime.Now} | {x.EndPointRoute} not found in database. Therefor IsUse property set to false."));
        }

        private static IList<EndPoint> ReadEndPoints()
        {
            List<EndPoint> endPoints = new();

            var assembly = Assembly.GetExecutingAssembly();
            var controllers = assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(ControllerBase)) && !x.IsAbstract).ToList();

            foreach (var controller in controllers)
            {
                var methods = controller.GetMethods().Where(x => x.GetCustomAttributes().Any(y => y.GetType().IsSubclassOf(typeof(HttpMethodAttribute))) && x.IsPublic);
                var controllerAttributes = controller.GetCustomAttributes();
                var currentRoute = controllerAttributes.FirstOrDefault(x => x.GetType() == typeof(RouteAttribute));

                foreach (var method in methods)
                {
                    var methodAttributes = method.GetCustomAttributes();
                    var currentActionAttribute = methodAttributes.FirstOrDefault(x => x.GetType().IsSubclassOf(typeof(HttpMethodAttribute)));
                    var actionTemplate = string.IsNullOrEmpty(((HttpMethodAttribute)currentActionAttribute)?.Template) ? "" : "/" + ((HttpMethodAttribute)currentActionAttribute)?.Template;
                    string fullPath = $"{((RouteAttribute)currentRoute).Template}{actionTemplate}";

                    EndPoint endpoint = new EndPoint
                    {
                        ControllerName = controller.Name,
                        EndPointRoute = fullPath,
                        MethodName = method.Name,
                        IsActive = true,
                        IsUse = true
                    };

                    if (currentActionAttribute!.GetType() == typeof(HttpGetAttribute))
                        endpoint.ActionTypeId = (long)ActionTypes.GET;

                    if (currentActionAttribute!.GetType() == typeof(HttpPostAttribute))
                        endpoint.ActionTypeId = (long)ActionTypes.POST;

                    if (currentActionAttribute!.GetType() == typeof(HttpPutAttribute))
                        endpoint.ActionTypeId = (long)ActionTypes.PUT;

                    if (currentActionAttribute!.GetType() == typeof(HttpDeleteAttribute))
                        endpoint.ActionTypeId = (long)ActionTypes.DELETE;

                    endPoints.Add(endpoint);
                }
            }

            return endPoints;
        }
    }
}
