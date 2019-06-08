using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Models
{
    public class PlayerConfiguration : IEntityTypeConfiguration <Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.HasAlternateKey(curPlayer => curPlayer.Name);
            
            builder
                .Property(player => player.Gender)
                .HasConversion(property => property.ToString(),
                    property => (PlayerGender) Enum.Parse(typeof(PlayerGender), property));
        }
    }
}