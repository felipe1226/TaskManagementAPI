using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.DTO.Category;
using TaskManagementAPI.Helpers;
using TaskManagementAPI.Interfaces;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Application
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly JsonResponse jsonResponse = JsonResponse.Instance;
        private readonly IMapper _mapper;
        private readonly ICategoryDomainService _categoryDomainService;

        public CategoryAppService(
            IMapper mapper,
            ICategoryDomainService categoryDomainService)
        {
            _mapper = mapper;
            _categoryDomainService = categoryDomainService;
        }

        public ActionResult<object> getCategories()
        {
            try
            {
                IEnumerable<CategoryDTO> categoriesDTO = _categoryDomainService.getCategories()
                    .ProjectTo<CategoryDTO>(_mapper.ConfigurationProvider)
                    .ToList();

                return jsonResponse.CreateSuccessResponse(categoriesDTO);
            }
            catch (Exception e)
            {
                return jsonResponse.CreateErrorResponse(e.Message);
            }
        }
    }
}
