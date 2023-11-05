using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.DTO.User;
using TaskManagementAPI.Interfaces;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Data.Repositories
{
    public class UserDomainService : IUserDomainService
    {
        private readonly DBContext _context;

        public UserDomainService(DBContext context)
        {
            _context = context;
        }

        public User getUserById(Guid id)
        {
            return _context.User
                .Where(user => user.Id.Equals(id))
                .Where(user => user.State)
                .Include(user => user.UserProfileNavigation)
                .FirstOrDefault();
        }

        public IQueryable<User> getUsers(UserFiltersDTO filters)
        {
            IQueryable<User> users = _context.User
                .Where(user => user.State)
                .Include(user => user.UserProfileNavigation);

            return users;
        }
    }
}
