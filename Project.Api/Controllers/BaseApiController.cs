using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Api.Controllers
{
    [Route("api/v{v:apiVersion}/project-structure")]
    [ApiVersion(1)]
    [ApiVersion(2)]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        public IActionResult HelloWorld()
        {
            return Ok("Hello, world!");
        }
    }
}
