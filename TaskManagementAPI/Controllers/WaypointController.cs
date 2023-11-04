using Microsoft.AspNetCore.Mvc;

namespace TaskManagementAPI.Controllers
{

    [ApiController]
    [Route("waypoint")]
    public class WaypointController : ControllerBase
    {

        [HttpPost("save")]
        public dynamic save()
        {
            return null;
        }

        [HttpPost("list")]
        public IEnumerable<dynamic> list()
        {
            return null;
        }

        [HttpPost("update")]
        public IEnumerable<dynamic> update()
        {
            return null;
        }

        [HttpPost("delete")]
        public IEnumerable<dynamic> delete()
        {
            return null;
        }
    }
}
