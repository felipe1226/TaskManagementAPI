using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.DTO;
using TaskManagementAPI.DTO.WorkTask;
using TaskManagementAPI.Interfaces;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class WorkTaskController : ControllerBase
    {
        private readonly IWorkTaskAppService _workTaskAppService;

        public WorkTaskController(IWorkTaskAppService workTaskAppService)
        {
            _workTaskAppService = workTaskAppService;
        }

        /// <summary>
        /// Guardar datos de una tarea
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("save")]
        public async Task<ActionResult<JsonResponseDTO>> save(WorkTaskSaveDTO data)
        {
            return _workTaskAppService.saveWorkTask(data);
        }

        /// <summary>
        /// Obtener datos de tarea por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get")]
        public async Task<ActionResult<JsonResponseDTO>> get(string id)
        {
            return _workTaskAppService.getWorkTask(id);
        }

        /// <summary>
        /// Obtener lista de tareas con filtros
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task<ActionResult<JsonResponseDTO>> list(WorkTaskFiltersDTO filters)
        {
            return _workTaskAppService.getWorkTasks(filters);
        }

        /// <summary>
        /// Guardar el cambio de estado de una tarea
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("update-status")]
        public async Task<ActionResult<JsonResponseDTO>> updateStatus(WorkTaskSaveDTO data)
        {
            return _workTaskAppService.updateStatus(data);
        }
    }
}
