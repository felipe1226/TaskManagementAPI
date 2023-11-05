namespace TaskManagementAPI.Models
{
    public class WorkTaskStatus
    {
        public Guid Id { get; set; }
        public Guid WorkTask {  get; set; }
        public Guid Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Observation {  get; set; }
        public bool State {  get; set; }

        public virtual WorkTask WorkTaskNavigation { get; set; }
        public virtual Status StatusNavigation { get; set; }
    }
}
