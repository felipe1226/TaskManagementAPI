namespace TaskManagementAPI.Models
{
    public class Location
    {
        public Location() 
        {
            Waypoints = new HashSet<Waypoint>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool State {  get; set; }

        public virtual ICollection<Waypoint> Waypoints { get; set; }
    }
}
