using CustomConstructorSamples.Configurations;
using CustomConstructorSamples.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomConstructorSamples
{
    public class MyDbContext : DbContext
    {
        public DbSet<Tweet> Tweets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog=MyDbContextDB; Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TweetConfiguration());
        }
    }
}
