using CustomConstructorSamples.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomConstructorSamples.Configurations
{
    internal class TweetConfiguration : IEntityTypeConfiguration<Tweet>
    {
        public void Configure(EntityTypeBuilder<Tweet> builder)
        {
            builder.HasKey("_id");
            builder.Property(p => p.UserId);
            builder.Property(p => p.Content).IsRequired().HasMaxLength(280);
        }
    }
}
