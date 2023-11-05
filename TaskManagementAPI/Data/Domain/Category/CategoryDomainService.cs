using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Interfaces;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Data.Domain
{
    public class CategoryDomainService : ICategoryDomainService
    {
        private readonly DBContext _context;

        public CategoryDomainService(DBContext context)
        {
            _context = context;
        }

        public IQueryable<Category> getCategories()
        {
            return _context.Category.
                Where(category => category.State);
        }
    }
}
