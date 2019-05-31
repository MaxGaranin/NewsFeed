using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NewsFeed.DataAccess;
using NewsFeed.Model.Entities;

namespace NewsFeed.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);

            var configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<NewsFeedDbContext>();
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlite(connectionString);

            using (var context = new NewsFeedDbContext(optionsBuilder.Options))
            {
                context.Database.Migrate();

                var user = new User
                {
                    Name = "Max",
                    SurName = "Garanin",
                    Nick = "MaG"
                };

                context.Users.Add(user);

                var newsFeedItem = new NewsFeedItem
                {
                    Author = user,
                    Content = "Hello, world",
                    PublishDate = DateTime.Now
                };

                context.NewsFeedItems.Add(newsFeedItem);

                context.SaveChanges();
            }

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}