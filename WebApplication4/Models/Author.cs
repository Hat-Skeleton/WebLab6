namespace WebApplication4.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Navigation property for the posts associated with the author
        public List<Post> Posts { get; set; }
    }
}
