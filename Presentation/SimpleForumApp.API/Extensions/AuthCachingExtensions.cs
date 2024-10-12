using SimpleForumApp.Application.UnitOfWork;

namespace SimpleForumApp.API.Extensions
{
    public static class AuthCachingExtensions
    {
        public static async Task CacheAuthInformations(this IServiceCollection services)
        {
            await CacheEndPointsWithPermissionsAsync(services);
            await CacheUsersWithPermissionsAsync(services);
        }

        private static async Task CacheEndPointsWithPermissionsAsync(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var unitOfWork = serviceProvider.GetService<IUnitOfWork>();

            var endPoints = await unitOfWork!.Context.Traceability.EndPointRepository.GetAllAsync();

            foreach ( var endPoint in endPoints )
            {
                var permissionOfEndPoint = await unitOfWork!.Context.Auth.EndPointPermissionRepository.GetAllPermissionsByEndPointAsync(endPoint.Id);

                string key = $"{endPoint.Id}, {endPoint.ActionTypeId}, {endPoint.MethodName}, {endPoint.EndPointRoute}";
                string value = string.Join(", ", permissionOfEndPoint.Select(x => x.PermissionId.ToString()));

                var isExists = await unitOfWork.Context.Cache.RedisCacheService.GetAsync(key);

                if (isExists != null)
                    await unitOfWork.Context.Cache.RedisCacheService.RemoveAsync(key);

                var result = await unitOfWork.Context.Cache.RedisCacheService.SetAsync(key, value, 10080, 86400);
                Console.WriteLine($"[{DateTime.Now}] Endpoint with {key} key added with {value} values.");
            }
        }

        private static async Task CacheUsersWithPermissionsAsync(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var unitOfWork = serviceProvider.GetService<IUnitOfWork>();

            var users = await unitOfWork!.Context.Identity.UserService.GetAllAsync();

            foreach ( var user in users )
            {
                var permissionsForUser = await unitOfWork.Context.Auth.UserRoleRepository.GetAllUserPermissionsByUserIdAsync(user.Id);

                string key = user.UserName;
                string value = string.Join(", ", permissionsForUser);

                var isExists = await unitOfWork.Context.Cache.RedisCacheService.GetAsync(key);

                if (isExists != null)
                    await unitOfWork.Context.Cache.RedisCacheService.RemoveAsync(key);

                var result = await unitOfWork.Context.Cache.RedisCacheService.SetAsync(key, value, 10080, 86400);
                Console.WriteLine($"[{DateTime.Now}] User with {key} key added with {value} values.");
            }
        }
    }
}
