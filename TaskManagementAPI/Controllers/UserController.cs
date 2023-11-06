using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.DTO;
using TaskManagementAPI.DTO.User;
using TaskManagementAPI.Interfaces;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServices;

        public UserController(
            IUserService userServices)
        {
            _userServices = userServices;
        }

        /// <summary>
        /// Obtener datos de usuario por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get")]
        public async Task<ActionResult<JsonResponseDTO>> get(string id)
        {
            return _userServices.getUser(id);
        }

        /// <summary>
        /// Obtener lista de usuarios
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task<ActionResult<JsonResponseDTO>> list(UserFiltersDTO filters)
        {
            return _userServices.getUsers(filters);
        }
    }
}
