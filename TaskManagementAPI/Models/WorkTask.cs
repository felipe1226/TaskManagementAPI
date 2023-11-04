namespace TaskManagementAPI.Models
{
    public class WorkTask
    {
        public WorkTask() 
        {
            WorkTaskStatuses = new HashSet<WorkTaskStatus>();
            Waypoints = new HashSet<Waypoint>();
        }

        public Guid Id { get; set; }
        public Guid User {  get; set; }
        public Guid Category { get; set; }
        public string Description { get; set; }
        public string? Observation { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool State {  get; set; }

        public virtual User UserNavigation { get; set; }
        public virtual Category CategoryNavigation { get; set; }

        public virtual ICollection<WorkTaskStatus> WorkTaskStatuses { get; set; }
        public virtual ICollection<Waypoint> Waypoints { get; set; }
    }
}
