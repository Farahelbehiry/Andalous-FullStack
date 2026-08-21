namespace WebApplication1.DTOs
{
    public class TaskItemDto
    {
        public int Id { get; set; }
        public string? Title { get; set; } 
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
