using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers
{

    [ApiController]
    [Route("category")]
    public class CategoryController : ControllerBase
    {

        private readonly DBContext _context;

        public CategoryController(DBContext context)
        {
            _context = context;
        }

        [HttpPost("list")]
        public async Task<IEnumerable<dynamic>> list()
        {
            return null;
        }
    }
}
