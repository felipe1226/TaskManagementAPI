using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.DTO;
using TaskManagementAPI.DTO.User;

namespace TaskManagementAPI.Interfaces
{
    public interface IUserService
    {
        ActionResult<JsonResponseDTO> getUser(string id);

        ActionResult<JsonResponseDTO> getUsers(UserFiltersDTO filters);
    }
}
