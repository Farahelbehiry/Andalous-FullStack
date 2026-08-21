namespace WebApplication1.Models
{
    public class TaskItem
    {  
        public int Id { get; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //foreign key
        public int UserId { get; set; }
        public User? User { get; set; }//navigation
       
    }
}

//private static int _nextId = 0;
/*
 *  public TaskItem()
        {
            _nextId++;
            Id = _nextId;
            CreatedAt = DateTime.UtcNow;
        }
 
 */
