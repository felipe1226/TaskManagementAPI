namespace TaskManagementAPI.Models
{
    public class User
    {
        public User() 
        {
            WorkTasks = new HashSet<WorkTask>();
        }

        public Guid Id { get; set; }
        public Guid UserProfile { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Phone {  get; set; }
        public bool State {  get; set; }

        public virtual UserProfile UserProfileNavigation { get; set; }

        public virtual ICollection<WorkTask> WorkTasks { get; set; }
    }
}
