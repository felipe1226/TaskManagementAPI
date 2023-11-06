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

        public User getUser(Guid id)
        {
            return _context.User
                .Where(user => user.Id.Equals(id))
                .Where(user => user.State)
                .Include(user => user.UserProfileNavigation)
                .FirstOrDefault();
        }

        public IQueryable<User> getUsers(UserFiltersDTO filters)
        {
            return _context.User
                .Where(user => user.State)
                .Include(user => user.UserProfileNavigation);
        }
    }
}
