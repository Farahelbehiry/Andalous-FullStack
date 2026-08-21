using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs
{
    public class UpdateTaskRequest
    {
        [Required]
        [MaxLength(100)]
        public string? Title { get; set; } 

        public bool IsCompleted { get; set; }
    }
}
