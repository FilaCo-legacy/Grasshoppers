using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Models
{
    public class MissionConfiguration : IEntityTypeConfiguration <Mission>
    {
        public void Configure(EntityTypeBuilder<Mission> builder)
        {
            builder.HasAlternateKey(mission => mission.Name);
        }
    }
}