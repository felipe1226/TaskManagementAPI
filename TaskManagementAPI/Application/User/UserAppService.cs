using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.DTO;
using TaskManagementAPI.DTO.User;
using TaskManagementAPI.Helpers;
using TaskManagementAPI.Interfaces;

namespace TaskManagementAPI.Services
{
    public class UserAppService : IUserService
    {
        private readonly JsonResponse jsonResponse = JsonResponse.Instance;
        private readonly IUserDomainService _userDomainServices;
        private readonly IMapper _mapper;

        public UserAppService(
            IUserDomainService userDomainServices,
            IMapper mapper) 
        {
            _userDomainServices = userDomainServices;
            _mapper = mapper;
        }

        public ActionResult<JsonResponseDTO> getUser(string id)
        {
            try
            {
                UserDTO userDTO = _mapper.Map<UserDTO>(_userDomainServices.getUser(Guid.Parse(id)));
                return jsonResponse.CreateSuccessResponse(userDTO);
            }
            catch (Exception e)
            {
                return jsonResponse.CreateErrorResponse(e.Message);
            }
        }

        public ActionResult<JsonResponseDTO> getUsers(UserFiltersDTO filters)
        {
            try
            {
                IEnumerable<UserDTO> usersDTO = _userDomainServices.getUsers(filters)
                    .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                    .ToList()
                    .OrderBy(user => user.Name);

                return jsonResponse.CreateSuccessResponse(usersDTO);
            }
            catch (Exception e)
            {
                return jsonResponse.CreateErrorResponse(e.Message);
            }
        }
    }
}
