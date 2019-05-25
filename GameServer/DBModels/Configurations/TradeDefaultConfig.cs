using System.Data.Entity.ModelConfiguration;

namespace GameServer.DBModels.Configurations
{
    public class TradeDefaultConfig : EntityTypeConfiguration<Trade>
    {
        public TradeDefaultConfig()
        {
            Property(trade => trade._firstPlayerItems).HasColumnName("FirstPlayerItems").IsRequired();
            Property(trade => trade._secondPlayerItems).HasColumnName("SecondPlayerItems").IsRequired();
        }
    }
}