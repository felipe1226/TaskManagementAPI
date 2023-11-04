using Microsoft.AspNetCore.Mvc;

namespace TaskManagementAPI.Controllers
{

    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {

        [HttpPost("save")]
        public async Task<dynamic> save()
        {
            return null;
        }

        [HttpPost("list")]
        public async Task<IEnumerable<dynamic>> list()
        {
            return null;
        }

        [HttpPost("update")]
        public async Task<dynamic> update()
        {
            return null;
        }
    }
}
