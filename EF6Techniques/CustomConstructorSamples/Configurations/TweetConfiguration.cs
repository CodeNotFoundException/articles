using CustomConstructorSamples.Models;
using System.Data.Entity.ModelConfiguration;

namespace CustomConstructorSamples.Configurations
{
    internal class TweetConfiguration : EntityTypeConfiguration<Tweet>
    {
        public TweetConfiguration()
        {
            //this.Property(p => p.Content).IsRequired().HasMaxLength(280);
        }
    }
}
