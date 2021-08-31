using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unosquare.Data.Models
{
    public class Item
    {
        public long ItemID { get; set; }

        public long ItemType { get; set; } //TODO: This should be an ID with a relationship to another table/Entity

        public long ItemStatus { get; set; }//TODO: This should be an ID with a relationship to another table/Entity

        public long Warehouse { get; set; }//TODO: This should be an ID with a relationship to another table/Entity

        public List<Item> Container { get; set; }//TODO: This should be an ID with a self-relationship

        //Navigation Properties
        //List<Warehouse>

    }
}
