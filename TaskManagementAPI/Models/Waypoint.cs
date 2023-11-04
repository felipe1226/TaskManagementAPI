using System.Net;

namespace TaskManagementAPI.Models
{
    public class Waypoint
    {
        public Guid Id { get; set; }
        public Guid WorkTask {  get; set; }
        public Guid Location {  get; set; } 
        public string Address { get; set; }
        public int Order { get; set; }
        public bool State { get; set; }

        public virtual WorkTask WorkTaskNavigation { get; set; }
        public virtual Location LocationNavigation { get; set; }

    }
}
