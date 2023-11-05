namespace TaskManagementAPI.DTO
{
    public class JsonResponseDTO
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }
    }
}
