
namespace TaskManagementAPI.DTO.WorkTask
{
    public class WorkTaskDTO
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }
        public DateTime DeadLine { get; set; }
        public string StatusName { get; set; }
        public bool CanComplete { get; set; }
        public IEnumerable<WaypointDTO> Waypoints { get; set; }
        public IEnumerable<StatusDTO> Statuses { get; set; }
    }
}
