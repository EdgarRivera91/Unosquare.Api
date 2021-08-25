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
        //TODO: Change to Fluent API instead of Data Annotations.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ItemID { get; set; }

        public string ItemType { get; set; } //TODO: This should be an ID with a relationship to another table/Entity
        
        public string ItemStatus { get; set; }//TODO: This should be an ID with a relationship to another table/Entity

        public string Warehouse { get; set; }//TODO: This should be an ID with a relationship to another table/Entity

        public long Container { get; set; }//TODO: This should be an ID with a self-relationship
    }
}
