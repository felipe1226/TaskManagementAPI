using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.DTO.Category;
using TaskManagementAPI.DTO;
using TaskManagementAPI.Helpers;
using TaskManagementAPI.Interfaces;
using TaskManagementAPI.DTO.Location;
using AutoMapper.QueryableExtensions;

namespace TaskManagementAPI.Application
{
    public class LocationAppService : ILocationAppService
    {
        private readonly JsonResponse jsonResponse = JsonResponse.Instance;
        private readonly IMapper _mapper;
        private readonly ILocationDomainService _locationDomainService;

        public LocationAppService(
            IMapper mapper,
            ILocationDomainService locationDomainService)
        {
            _mapper = mapper;
            _locationDomainService = locationDomainService;
        }

        public ActionResult<JsonResponseDTO> getLocations()
        {
            try
            {
                IEnumerable<LocationDTO> locationsDTO = _locationDomainService.getLocations()
                    .ProjectTo<LocationDTO>(_mapper.ConfigurationProvider)
                    .ToList();

                return jsonResponse.CreateSuccessResponse(locationsDTO);
            }
            catch (Exception e)
            {
                return jsonResponse.CreateErrorResponse(e.Message);
            }
        }
    }
}
