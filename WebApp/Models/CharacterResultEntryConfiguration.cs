using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Models
{
    public class CharacterResultEntryConfiguration : IEntityTypeConfiguration <CharacterResultEntry>
    {
        public void Configure(EntityTypeBuilder<CharacterResultEntry> builder)
        {
            builder.HasKey(charResEntry => new {charResEntry.PlayerId, charResEntry.GameSessionId});
        }
    }
}