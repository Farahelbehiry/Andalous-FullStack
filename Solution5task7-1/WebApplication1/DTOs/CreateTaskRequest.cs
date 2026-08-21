using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs
{
    public class CreateTaskRequest
    {
        [Required]
        [MaxLength(100)]
        public string? Title { get; set; } 

        public int UserId { get; set; }
    }
}
