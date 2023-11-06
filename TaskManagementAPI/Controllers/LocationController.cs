using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.DTO;
using TaskManagementAPI.Interfaces;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/location")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationAppService _locationAppService;

        public LocationController(
            ILocationAppService locationAppService)
        {
            _locationAppService = locationAppService;
        }

        /// <summary>
        /// Obtener lista de localidades
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ActionResult<JsonResponseDTO>> getLocations()
        {
            return _locationAppService.getLocations();
        }
    }
}
