using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.DTO.User;
using TaskManagementAPI.Interfaces;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers
{

    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {

        private readonly DBContext _context;
        private readonly IUserService _userServices;

        public UserController(
            DBContext context,
            IUserService userServices)
        {
            _context = context;
            _userServices = userServices;
        }

        [HttpPost("save")]
        public async Task<ActionResult<dynamic>> save()
        {
            return null;
        }

        [HttpPost("list")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> list(UserFiltersDTO filters)
        {
            return _userServices.getUsers(filters);
        }

        [HttpPost("update")]
        public async Task<dynamic> update()
        {
            return null;
        }
    }
}
