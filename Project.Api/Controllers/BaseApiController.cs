using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Api.Controllers
{
    [Route("api/<your-system-name>")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}
