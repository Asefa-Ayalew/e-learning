namespace ELearning.Api.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set;} = DateTime.UtcNow;
        public List<Enrollment> Enrollments { get; set; } = new();
    }
}   