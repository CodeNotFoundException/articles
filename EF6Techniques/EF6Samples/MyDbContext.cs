using EF6Samples.Models;
using System.Data.Entity;

namespace EF6Samples
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
