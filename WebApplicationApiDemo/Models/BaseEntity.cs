namespace WebApplicationApiDemo.Models
{
    public abstract class BaseEntity
    {
        // Primary Key
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Status { get; set; } = 1; // Assuming 1 is for active status
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
