using Microsoft.AspNetCore.Mvc;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("task")]
    public class TaskController : ControllerBase
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

        [HttpPost("delete")]
        public async Task<dynamic> delete()
        {
            return null;
        }
    }
}
