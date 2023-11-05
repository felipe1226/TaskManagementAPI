namespace TaskManagementAPI.DTO.WorkTask
{
    public class WaypointSaveDTO
    {
        public string? WorkTaskId { get; set; }
        public string LocationId { get; set; }
        public string Address { get; set; }
        public int Order { get; set; }
    }
}
