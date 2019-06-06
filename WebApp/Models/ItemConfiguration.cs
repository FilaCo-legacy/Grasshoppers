using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Models
{
    public class ItemConfiguration : IEntityTypeConfiguration <Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder
                .Property(curItem => curItem.Rarity)
                .HasConversion(property => property.ToString(),
                    property => (ItemRarity) Enum.Parse(typeof(ItemRarity), property));
        }
    }
}