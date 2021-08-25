using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Unosquare.Data.Models;
using Unosquare.Services.Contracts;

namespace Unosquare.Services.Services
{
    
    public class ItemService : IItemService<Item>
    {
        readonly ItemContext _itemContext;
        public ItemService(ItemContext context)
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

        //TODO: Implement on the other side.
        //Usage example _itemContext.GetAllItems(x => x.ContainerId == 1, x => x.Born);
        public IEnumerable<Item> GetAllItems<T>(Expression<Func<Item, bool>> predicate, Expression<Func<Item, T>> orderBy = null)
        {
            return orderBy == null ? _itemContext.Items.Where(predicate) : _itemContext.Items.Where(predicate).OrderBy(orderBy);
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
