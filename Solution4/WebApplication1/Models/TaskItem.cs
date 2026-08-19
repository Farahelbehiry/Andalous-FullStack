namespace WebApplication1.Models
{
    public class TaskItem
    {
        private static int _nextId = 0;
        public int Id { get; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public DateTime? CreatedAt { get; set; }

        //foreign key
        public int UserId { get; set; }
        public User? User { get; set; }//navigation

        public TaskItem()
        {
            _nextId++;
            Id = _nextId;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
