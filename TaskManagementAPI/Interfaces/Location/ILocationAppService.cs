using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.DTO;

namespace TaskManagementAPI.Interfaces
{
    public interface ILocationAppService
    {
        ActionResult<JsonResponseDTO> getLocations();
    }
}
