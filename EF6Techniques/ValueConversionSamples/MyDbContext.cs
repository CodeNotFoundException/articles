using ValueConversionSamples.Models;
using System.Data.Entity;
using ValueConversionSamples.Configurations;

namespace ValueConversionSamples
{
    public class MyDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public MyDbContext() : base("name=MyDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonConfiguration());
        }
    }
}
