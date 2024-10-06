using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.Application.UnitOfWork;

namespace SimpleForumApp.API.Controllers.CacheTest
{
    [Route("api/in-memory-cache-test")]
    [ApiController]
    public class InMemoryCacheTestController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public InMemoryCacheTestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("get-item")]
        public async Task<IActionResult> GetItemAsync([FromQuery] string key)
            => Ok(await _unitOfWork.Context.Cache.InMemoryCacheService.GetAsync<string>(key));

        [HttpPost("set-item")]
        public async Task<IActionResult> SetItemAsync([FromQuery] string key, string value, int ex1, int ex2)
            => Ok(await _unitOfWork.Context.Cache.InMemoryCacheService.SetAsync<string>(key, value, ex1, ex2));

        [HttpGet("get-or-create-item")]
        public async Task<IActionResult> GetOrCreateItemAsync([FromQuery] string key, string value, int ex1, int ex2)
            => Ok(await _unitOfWork.Context.Cache.InMemoryCacheService.GetOrCreateAsync<string>(key, value, ex1, ex2));

        [HttpDelete("delete-item")]
        public async Task<IActionResult> DeleteItemAsync([FromQuery] string key)
            => Ok(await _unitOfWork.Context.Cache.InMemoryCacheService.RemoveAsync(key));

        [HttpGet("get-from-redis")]
        public async Task<IActionResult> GetFromRedisAsync([FromQuery] string key)
            => Ok(await _unitOfWork.Context.Cache.RedisCacheService.GetAsync(key));

        [HttpPost("set-to-redis")]
        public async Task<IActionResult> SetToRedisAsync([FromQuery] string key, string value, int ex1, int ex2)
            => Ok(await _unitOfWork.Context.Cache.RedisCacheService.SetAsync(key, value, ex1, ex2));

        [HttpDelete("remove-from-redis")]
        public async Task<IActionResult> RemoveFromRedisAsync([FromQuery] string key)
            => Ok(await _unitOfWork.Context.Cache.RedisCacheService.RemoveAsync(key));
    }
}
