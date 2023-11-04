namespace TaskManagementAPI.Models
{
    public class Category
    {
        public Category() 
        {
            WorkTasks = new HashSet<WorkTask>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool State {  get; set; }

        public virtual ICollection<WorkTask> WorkTasks { get; set; }
    }
}
