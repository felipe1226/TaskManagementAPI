using TaskManagementAPI.Models;

namespace TaskManagementAPI.Interfaces
{
    public interface ICategoryDomainService
    {
        IQueryable<Category> getCategories();
    }
}