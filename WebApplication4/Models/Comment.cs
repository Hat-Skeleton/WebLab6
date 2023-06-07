namespace WebApplication4.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign key property for the associated post
        public int PostId { get; set; }
        // Navigation property for the post associated with the comment
        public Post? Post { get; set; }
    }
}
