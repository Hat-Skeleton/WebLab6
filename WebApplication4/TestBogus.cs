using Bogus;
using System;
using WebApplication4.Models;

namespace WebApplication4
{
    public class TestBogus
    {
        public static void BogusTest()
        {
            var authorFaker = new Faker<Author>()
        .RuleFor(a => a.Name, f => f.Name.FullName())
        .RuleFor(a => a.Email, f => f.Internet.Email());

            // Generate a fake author
            var author = authorFaker.Generate();

            // Print the generated author details
            Console.WriteLine($"Generated Author: Name - {author.Name}, Email - {author.Email}");

        }
    }
}
