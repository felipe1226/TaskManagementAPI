using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Interfaces
{
    public interface ICategoryAppService
    {
        ActionResult<object> getCategories();
    }
}
