namespace TaskManagementAPI.Models
{
    public class UserProfile
    {
        public UserProfile() 
        {
            Users = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool State {  get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
