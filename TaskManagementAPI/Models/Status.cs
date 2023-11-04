using System.Threading.Tasks;

namespace TaskManagementAPI.Models
{
    public class Status
    {
        public Status() 
        {
            WorkTaskStatuses = new HashSet<WorkTaskStatus>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool State {  get; set; }

        public virtual ICollection<WorkTaskStatus> WorkTaskStatuses { get; set; }
    }
}
