using Bogus;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet for the Post model
        public DbSet<Post> Posts { get; set; }

        // DbSet for the Comment model
        public DbSet<Comment> Comments { get; set; }

        // DbSet for the Author model
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //// Configure relationships between models
            //modelBuilder.Entity<Post>()
            //    .HasMany(p => p.Comments)
            //    .WithOne(c => c.Post)
            //    .HasForeignKey(c => c.PostId);

            //modelBuilder.Entity<Post>()
            //    .HasOne(p => p.Author)
            //    .WithMany() // Updated relationship definition
            //    .HasForeignKey(p => p.AuthorId);



            //base.OnModelCreating(modelBuilder);

            // Faker for generating fake authors
            var authorFaker = new Faker<Author>()
                .RuleFor(a => a.Name, f => f.Person.FullName)
                .RuleFor(a => a.Email, f => f.Person.Email);

            // Generate 5 fake authors
            var authors = authorFaker.Generate(5);

            // Faker for generating fake posts
            var postFaker = new Faker<Post>()
                .RuleFor(p => p.Title, f => f.Lorem.Sentence())
                .RuleFor(p => p.Content, f => f.Lorem.Paragraph())
                .RuleFor(p => p.CreatedAt, f => f.Date.Past())
                .RuleFor(p => p.AuthorId, f => f.PickRandom(authors).Id);

            // Generate 10 fake posts
            var posts = postFaker.Generate(10);

            // Faker for generating fake comments
            var commentFaker = new Faker<Comment>()
                .RuleFor(c => c.Text, f => f.Lorem.Sentence())
                .RuleFor(c => c.CreatedAt, f => f.Date.Past())
                .RuleFor(c => c.PostId, f => f.PickRandom(posts).Id);

            // Generate 20 fake comments
            var comments = commentFaker.Generate(20);

            // Add the generated data to the corresponding tables
            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<Post>().HasData(posts);
            modelBuilder.Entity<Comment>().HasData(comments);

            base.OnModelCreating(modelBuilder);
        }
    }
}
