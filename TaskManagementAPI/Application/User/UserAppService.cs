using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.DTO.User;
using TaskManagementAPI.Interfaces;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services
{
    public class UserAppService : IUserService
    {
        private readonly IUserDomainService _userDomainServices;

        public UserAppService(
            IUserDomainService userDomainServices) 
        {
            _userDomainServices = userDomainServices;
        }

        public ActionResult<UserDTO> getUserById(string id)
        {
            try
            {
                User user = _userDomainServices.getUserById(Guid.Parse(id));

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult<IEnumerable<UserDTO>> getUsers(UserFiltersDTO filters)
        {
            try
            {
                IQueryable<User> users = _userDomainServices.getUsers(filters);

                IEnumerable<UserDTO> usersDTO = users.Select(user => new UserDTO
                    {
                        Id = user.Id,
                        ProfileName = user.UserProfileNavigation.Name,
                        Name = $"{user.Name} {user.Lastname}",
                        Phone = user.Phone
                    })
                    ;


                return usersDTO.OrderBy(user => user.Name).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
