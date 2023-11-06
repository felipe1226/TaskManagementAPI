using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.DTO;
using TaskManagementAPI.Interfaces;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(
            ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        /// <summary>
        /// Obtener lista de categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ActionResult<JsonResponseDTO>> getCategories()
        {
            return _categoryAppService.getCategories();
        }
    }
}
