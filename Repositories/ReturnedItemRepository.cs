using LPNU_LostAndFound.Data;
using LPNU_LostAndFound.Interfaces;
using LPNU_LostAndFound.Models;
using System.Collections.Generic;
using System.Linq;

namespace LPNU_LostAndFound.Repositories
{
    public class ReturnedItemRepository : IReturnedItemRepository
    {
        private readonly LpnuContext _context;

        public ReturnedItemRepository(LpnuContext context)
        {
            _context = context;
        }

        public void AddReturnedItem(ReturnedItem ret)
        {
            _context.ReturnedItems.Add(ret);
            _context.SaveChanges();
        }

        public IEnumerable<ReturnedItem> GetAllReturned()
        {
            return _context.ReturnedItems.ToList();
        }
    }
}
