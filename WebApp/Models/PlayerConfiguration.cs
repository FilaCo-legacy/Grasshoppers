using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Models
{
    public class PlayerConfiguration : IEntityTypeConfiguration <Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasAlternateKey(curPlayer => curPlayer.Name);
        }
    }
}