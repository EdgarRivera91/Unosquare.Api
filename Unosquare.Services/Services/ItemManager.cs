using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unosquare.Data.Models;
using Unosquare.Services.Contracts;

namespace Unosquare.Services.Services
{
    //TODO: For naming convension you should be using the "Service" word if its a service, in this case ItemService with IItemService interface
    public class ItemManager : I_ItemManager<Item>
    {
        readonly ItemContext _itemContext;
        public ItemManager(ItemContext context)
        {
            _itemContext = context;
        }
        public IEnumerable<Item> GetAll()
        {
            return _itemContext.Items.ToList();
        }
        public Item Get(long id)
        {

            return _itemContext.Items
                .FirstOrDefault(i => i.ItemID == id);
        }
        public void Add(Item entity)
        {
            _itemContext.Items.Add(entity);
            _itemContext.SaveChanges();
        }
        public void Update(Item Item, Item entity)
        {
            Item.ItemType = entity.ItemType;
            Item.ItemStatus = entity.ItemStatus;
            Item.Warehouse = entity.Warehouse;
            Item.Container = entity.Container;
            _itemContext.SaveChanges();
        }
        public void Delete(Item Item)
        {
            _itemContext.Items.Remove(Item);
            _itemContext.SaveChanges();
        }
    }
}
