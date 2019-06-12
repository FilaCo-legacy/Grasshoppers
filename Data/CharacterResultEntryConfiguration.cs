using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grasshoppers.Data
{
    public class CharacterResultEntryConfiguration : IEntityTypeConfiguration <CharacterResultEntry>
    {
        public void Configure(EntityTypeBuilder<CharacterResultEntry> builder)
        {
            builder.HasKey(charResEntry => new {PlayerId = charResEntry.CharacterId, charResEntry.GameSessionId});
        }
    }
}