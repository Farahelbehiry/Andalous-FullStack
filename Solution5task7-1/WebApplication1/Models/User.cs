namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; }

        public ICollection<TaskItem> TaskItems { get; set; }=new List<TaskItem>();
    }
}
