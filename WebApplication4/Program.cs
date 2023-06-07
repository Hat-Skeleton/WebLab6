using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApplication4;
using WebApplication4.Models;



var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("YourConnectionStringHere")
            .Options;

using (var context = new ApplicationDbContext(options))
{
    // Seed the Post entities
    if (!context.Posts.Any())
    {
        var posts = new List<Post>
                {
                    new Post { Id = 1, Title = "Post 1", Content = "Content 1", CreatedAt = DateTime.Now },
                    new Post { Id = 2, Title = "Post 2", Content = "Content 2", CreatedAt = DateTime.Now },
                    // Add more seeded posts here
                };

        context.Posts.AddRange(posts);
        context.SaveChanges();
    }

    // Seed the Comment entities
    if (!context.Comments.Any())
    {
        var comments = new List<Comment>
                {
                    new Comment { Id = 1, Text = "Comment 1", CreatedAt = DateTime.Now, PostId = 1 },
                    new Comment { Id = 2, Text = "Comment 2", CreatedAt = DateTime.Now, PostId = 2 },
                    // Add more seeded comments here
                };

        context.Comments.AddRange(comments);
        context.SaveChanges();
    }

    // Seed the Author entities
    if (!context.Authors.Any())
    {
        var authors = new List<Author>
                {
                    new Author { Id = 1, Name = "John Doe", Email = "johndoe@example.com", PostId = 1 },
                    new Author { Id = 2, Name = "Jane Smith", Email = "janesmith@example.com", PostId = 2 },
                    // Add more seeded authors here
                };

        context.Authors.AddRange(authors);
        context.SaveChanges();
    }
}

//TestBogus.BogusTest();
var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("TodoList"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BlogAPI", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlogAPI v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
