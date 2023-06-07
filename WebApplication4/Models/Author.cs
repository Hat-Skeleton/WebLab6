namespace WebApplication4.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Foreign key property for the associated post
        public int PostId { get; set; }
        // Navigation property for the post associated with the author
        public Post Post { get; set; }
    }
}
