using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.Application.UnitOfWork;

namespace SimpleForumApp.API.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
