using Microsoft.EntityFrameworkCore;
using LPNU_LostAndFound.Models;

namespace LPNU_LostAndFound.Data
{
    public class LpnuContext : DbContext
    {
        public LpnuContext(DbContextOptions<LpnuContext> options)
            : base(options)
        {}

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ReturnedItem> ReturnedItems { get; set; }
    }
}
