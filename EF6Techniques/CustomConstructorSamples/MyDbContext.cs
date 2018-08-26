using CustomConstructorSamples.Models;
using System.Data.Entity;
using CustomConstructorSamples.Configurations;

namespace CustomConstructorSamples
{
    public class MyDbContext : DbContext
    {
        public DbSet<Tweet> Tweets { get; set; }

        public MyDbContext() : base("name=MyDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TweetConfiguration());
        }
    }
}
