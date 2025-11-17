using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LPNU_LostAndFound.Data;
using LPNU_LostAndFound.Interfaces;
using LPNU_LostAndFound.Repositories;
using LPNU_LostAndFound.Models;

namespace LPNU_LostAndFound
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddDbContext<LpnuContext>(options =>
                options.UseSqlServer("Server=YOUR_SERVER;Database=LPNU_LostAndFoundDB;Trusted_Connection=True;TrustServerCertificate=True;"));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IReturnedItemRepository, ReturnedItemRepository>();

            var provider = services.BuildServiceProvider();

            var userRepo = provider.GetRequiredService<IUserRepository>();
            var itemRepo = provider.GetRequiredService<IItemRepository>();
            var retRepo = provider.GetRequiredService<IReturnedItemRepository>();

            Console.WriteLine("=== LPNU LOST & FOUND ===");

            userRepo.AddUser(new User
            {
                UserEmail = "student@lpnu.ua",
                UserPassword = "pass123",
                NumOfFoundedItems = 4,
                NumOfLostedItems = 2,
                UserStatus = "Amateur(3-10)"
            });

            itemRepo.AddItem(new Item
            {
                ItemName = "Студентський квиток",
                ItemDescription = "Знайдено біля ГК",
                ItemFounder = 1,
                ItemStatus = "NotReturned"
            });

            itemRepo.UpdateItemStatus(1, "Returned");

            retRepo.AddReturnedItem(new ReturnedItem
            {
                LosterID = 1,
                RetDate = DateTime.Now
            });

            Console.WriteLine("Готово!");
        }
    }
}
