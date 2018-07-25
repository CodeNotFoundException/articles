using ValueConversionSamples.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ValueConversionSamples.Configurations
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(20);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(20);
        }
    }
}
