using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Unosquare.Data.Models
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Move to Configuration files with fluentAPI and using the IEntityConfiguration interface
            modelBuilder.Entity<Item>().HasData(new Item
            {
                ItemID = 1,
                ItemType = "Coke",
                ItemStatus = "Available",
                Warehouse = "Items",
                Container = 1,
            });
        }
    }
}
