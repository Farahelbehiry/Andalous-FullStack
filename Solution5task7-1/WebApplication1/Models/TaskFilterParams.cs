namespace WebApplication1.Models
{
    public class TaskFilterParams:PaginationParams
    {
        public string? Search { get; set; }
        public bool? IsCompleted { get; set; }
        public string? SortBy { get; set; } = "createdAt";
        public string? Order { get; set; } = "asc";
    }
}
