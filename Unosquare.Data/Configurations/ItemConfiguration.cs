using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unosquare.Data.Models;

namespace Unosquare.Data.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.ItemID);
            builder.Property(x => x.ItemID).ValueGeneratedOnAdd();

            builder.HasData(Get());



        }

        public List<Item> Get()
        {
            return new List<Item>()
            {
                new Item{ItemID = 1,ItemType = "Coke",ItemStatus = "Available",Warehouse = "Items",Container = 1 },
                new Item{ItemID = 2,ItemType = "Coke",ItemStatus = "Available",Warehouse = "Items",Container = 2 }

            };
        }
    }
}
