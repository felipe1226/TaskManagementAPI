using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.DTO;
using TaskManagementAPI.DTO.WorkTask;
using TaskManagementAPI.Interfaces;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("task")]
    public class WorkTaskController : ControllerBase
    {

        private readonly IWorkTaskAppService _workTaskAppService;

        public WorkTaskController(IWorkTaskAppService workTaskAppService)
        {
            _workTaskAppService = workTaskAppService;
        }

        [HttpPost("save")]
        public async Task<dynamic> save(WorkTaskSaveDTO data)
        {
            return _workTaskAppService.saveWorkTask(data);
        }

        [HttpPost("get")]
        public async Task<ActionResult<JsonResponseDTO>> get(string id)
        {
            return _workTaskAppService.getWorkTask(id);
        }

        [HttpPost("list")]
        public async Task<ActionResult<JsonResponseDTO>> list(WorkTaskFiltersDTO filters)
        {
            return _workTaskAppService.getWorkTasks(filters);
        }

        [HttpPost("update")]
        public async Task<ActionResult> update()
        {
            return null;
        }

        [HttpPost("update-status")]
        public async Task<ActionResult<JsonResponseDTO>> updateStatus(WorkTaskSaveDTO data)
        {
            return _workTaskAppService.updateStatus(data);
        }

        [HttpPost("delete")]
        public async Task<dynamic> delete()
        {
            return null;
        }
    }
}
