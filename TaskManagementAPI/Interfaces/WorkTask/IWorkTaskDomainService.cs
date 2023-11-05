using TaskManagementAPI.DTO.WorkTask;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Interfaces
{
    public interface IWorkTaskDomainService
    {
        int saveWorkTask(WorkTask workTask);

        int saveWorkTaskStatus(WorkTaskStatus workTaskStatus);

        int saveWaypoints(IEnumerable<Waypoint> waypoints);

        public WorkTask getWorkTasksById(Guid id);

        IQueryable<WorkTask> getWorkTasks(WorkTaskFiltersDTO filters);

        int updateStatus(WorkTaskStatus workTaskStatus);
    }
}
