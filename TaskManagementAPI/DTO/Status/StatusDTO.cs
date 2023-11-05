namespace TaskManagementAPI.DTO
{
    public class StatusDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Observation { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
