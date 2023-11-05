using TaskManagementAPI.DTO.User;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Interfaces
{
    public interface IUserDomainService
    {

        User getUserById(Guid id);

        IQueryable<User> getUsers(UserFiltersDTO filters);
    }
}
