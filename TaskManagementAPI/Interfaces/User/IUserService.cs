using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.DTO.User;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Interfaces
{
    public interface IUserService
    {
        ActionResult<UserDTO> getUserById(string id);

        ActionResult<IEnumerable<UserDTO>> getUsers(UserFiltersDTO filters);
    }
}
