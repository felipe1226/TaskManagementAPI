using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.DTO;
using TaskManagementAPI.DTO.WorkTask;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Interfaces
{
    public interface IWorkTaskAppService
    {

        ActionResult<dynamic> saveWorkTask(WorkTaskSaveDTO data);

        ActionResult<JsonResponseDTO> getWorkTask(string id);

        ActionResult<JsonResponseDTO> getWorkTasks(WorkTaskFiltersDTO filters);

        ActionResult<JsonResponseDTO> updateStatus(WorkTaskSaveDTO data);

    }
}
