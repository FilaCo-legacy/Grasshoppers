using System.Data.Entity.ModelConfiguration;

namespace GameServer.DBModels.Configurations
{
    public class MapDefaultConfig : EntityTypeConfiguration<Map>
    {
        public MapDefaultConfig()
        {
            Property(map => map._mapInfo).HasColumnName("MapInfo").IsRequired();
        }
    }
}