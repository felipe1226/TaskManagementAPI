using TaskManagementAPI.Models;

namespace TaskManagementAPI.DTO.WorkTask
{
    public class WorkTaskSaveDTO
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public string? CategoryId { get; set; }
        public string? Description { get; set; }
        public string? Observation { get; set; }
        public string? DeadLine { get; set; }
        public string? StatusId { get; set; }
        public string? StatusCode { get; set; }
        public string? StatusObservation { get; set; }
        public List<WaypointSaveDTO>? WaypointsDTO { get; set; }
    }
}
