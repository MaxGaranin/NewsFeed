using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NewsFeed.Model.Entities;

namespace NewsFeed.DataAccess
{
    public class MoviesDbContextFactory : IDesignTimeDbContextFactory<NewsFeedDbContext>
    {
        NewsFeedDbContext IDesignTimeDbContextFactory<NewsFeedDbContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NewsFeedDbContext>();
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlite("Filename=NewsFeed.db");

            return new NewsFeedDbContext(optionsBuilder.Options);
        }
    }

    public class NewsFeedDbContext : DbContext
    {
        public DbSet<NewsFeedItem> NewsFeedItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public NewsFeedDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}