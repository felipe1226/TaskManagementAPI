using TaskManagementAPI.DTO.User;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Interfaces
{
    public interface IUserDomainService
    {
        User getUser(Guid id);

        IQueryable<User> getUsers(UserFiltersDTO filters);
    }
}
