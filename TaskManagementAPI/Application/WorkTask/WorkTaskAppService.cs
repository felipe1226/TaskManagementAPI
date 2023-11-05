using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Data.Domain;
using TaskManagementAPI.DTO;
using TaskManagementAPI.DTO.Category;
using TaskManagementAPI.DTO.WorkTask;
using TaskManagementAPI.Helpers;
using TaskManagementAPI.Interfaces;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services
{
    public class WorkTaskAppService : IWorkTaskAppService
    {
        private readonly JsonResponse jsonResponse = JsonResponse.Instance;
        private readonly IWorkTaskDomainService _workTaskDomainService;
        private readonly IMapper _mapper;

        public WorkTaskAppService(
            IWorkTaskDomainService workTaskDomainService,
            IMapper mapper)
        {
            _workTaskDomainService = workTaskDomainService;
            _mapper = mapper;
        }

        public ActionResult<dynamic> saveWorkTask(WorkTaskSaveDTO data)
        {
            try
            {
                WorkTask workTask = _mapper.Map<WorkTask>(data);
                data.Id = workTask.Id.ToString();
                int workTaskSave = _workTaskDomainService.saveWorkTask(workTask);
                int workTaskStatusSave = 1;
                int waypointsSave = 1;

                if (!string.IsNullOrEmpty(data.StatusId))
                {
                    WorkTaskStatus workTaskStatus = _mapper.Map<WorkTaskStatus>(data);
                    workTaskStatusSave = _workTaskDomainService.saveWorkTaskStatus(workTaskStatus);
                }

                if (data.WaypointsDTO != null && data.WaypointsDTO.Any())
                {
                    data.WaypointsDTO.ToList().ForEach(waypoint => waypoint.WorkTaskId = data.Id.ToString());
                    IEnumerable<Waypoint> waypoints = data.WaypointsDTO.AsQueryable().ProjectTo<Waypoint>(_mapper.ConfigurationProvider)
                    .ToList();

                    //waypoints = _mapToWaypoints(workTask.Id, data.Waypoints);
                    waypointsSave = _workTaskDomainService.saveWaypoints(waypoints);
                }

                if (workTaskSave != null && workTaskStatusSave != null && waypointsSave != null )
                    return jsonResponse.CreateSuccessResponse(true);

                return jsonResponse.CreateSuccessResponse(false, "No se registró correstamente");
            }
            catch (Exception e)
            {
                return jsonResponse.CreateErrorResponse(e.Message);
            }
        }

        public ActionResult<JsonResponseDTO> getWorkTask(string id)
        {
            try
            {
                WorkTaskDTO workTask = _mapper.Map<WorkTaskDTO>(_workTaskDomainService.getWorkTasksById(Guid.Parse(id)));
                return jsonResponse.CreateSuccessResponse(workTask);
            }
            catch (Exception e)
            {
                return jsonResponse.CreateErrorResponse(e.Message);
            }
        }

        public ActionResult<JsonResponseDTO> getWorkTasks(WorkTaskFiltersDTO filters)
        {
            try
            {
                IEnumerable<WorkTaskDTO> workTasksDTO = _workTaskDomainService.getWorkTasks(filters)
                    .ProjectTo<WorkTaskDTO>(_mapper.ConfigurationProvider)
                    .ToList();

                return jsonResponse.CreateSuccessResponse(workTasksDTO);
            }
            catch (Exception e)
            {
                return jsonResponse.CreateErrorResponse(e.Message);
            }
        }

        public ActionResult<JsonResponseDTO> updateStatus(WorkTaskSaveDTO data)
        {
            try
            {
                WorkTaskStatus workTaskStatus = _mapper.Map<WorkTaskStatus>(data);
                if (_workTaskDomainService.updateStatus(workTaskStatus) != null)
                    return jsonResponse.CreateSuccessResponse(true);

                return jsonResponse.CreateSuccessResponse(false, "No se actualizó correctamente");
            }
            catch (Exception e)
            {
                return jsonResponse.CreateErrorResponse(e.Message);
            }
        }

    }
}
