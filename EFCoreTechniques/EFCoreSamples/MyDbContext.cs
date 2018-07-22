using EFCoreSamples.Configurations;
using EFCoreSamples.Converters;
using EFCoreSamples.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System.Linq;

namespace EFCoreSamples
{
    public class MyDbContext : DbContext
    {
        public static readonly LoggerFactory loggerFactory = new LoggerFactory(new[] { new ConsoleLoggerProvider((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information, true) });

        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(loggerFactory)
                .UseSqlServer(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog=MyDbContextDB; Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties().Where(p => p.ClrType == typeof(Gender) || p.ClrType == typeof(Gender?)))
                {
                    property.SetValueConverter(new GenderToStringConverter());
                    property.SetMaxLength(1);
                    property.IsUnicode(false);
                    property.SqlServer().ColumnType = "char";
                }
            }
        }
    }
}
