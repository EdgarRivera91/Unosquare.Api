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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ItemID { get; set; }

        public string ItemType { get; set; }
        
        public string ItemStatus { get; set; }

        public string Warehouse { get; set; }

        public long Container { get; set; }
    }
}
