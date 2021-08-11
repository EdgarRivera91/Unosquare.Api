using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Unosquare.Data.Models
{
    class Warehouse:DbContext
    {
        public Warehouse() : base()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<Warehouse>());
        }

        public DbSet<Item> Items
        {
            get;
            set;
        }
    }
}
