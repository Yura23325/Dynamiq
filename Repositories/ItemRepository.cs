using LPNU_LostAndFound.Data;
using LPNU_LostAndFound.Interfaces;
using LPNU_LostAndFound.Models;
using System.Collections.Generic;
using System.Linq;

namespace LPNU_LostAndFound.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly LpnuContext _context;

        public ItemRepository(LpnuContext context)
        {
            _context = context;
        }

        public void AddItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }

        public void UpdateItemStatus(int id, string status)
        {
            var item = _context.Items.FirstOrDefault(i => i.ItemID == id);
            if (item != null)
            {
                item.ItemStatus = status;
                _context.SaveChanges();
            }
        }
    }
}
