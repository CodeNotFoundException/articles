using ValueConversionSamples.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueConversionSamples.Configurations
{
    internal class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            this.Property(p => p.FirstName).IsRequired().HasMaxLength(20);
            this.Property(p => p.LastName).IsRequired().HasMaxLength(20);
            this.Property(p => p.GenderToString).HasColumnName("Gender").IsUnicode(false).HasMaxLength(1).IsFixedLength();
            this.Ignore(p => p.Gender);
        }
    }
}
