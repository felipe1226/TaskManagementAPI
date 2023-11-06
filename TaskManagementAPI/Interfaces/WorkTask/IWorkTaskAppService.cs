using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.DTO;
using TaskManagementAPI.DTO.WorkTask;

namespace TaskManagementAPI.Interfaces
{
    public interface IWorkTaskAppService
    {
        ActionResult<JsonResponseDTO> saveWorkTask(WorkTaskSaveDTO data);

        ActionResult<JsonResponseDTO> getWorkTask(string id);

        ActionResult<JsonResponseDTO> getWorkTasks(WorkTaskFiltersDTO filters);

        ActionResult<JsonResponseDTO> updateStatus(WorkTaskSaveDTO data);
    }
}
