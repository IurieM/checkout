using Basket.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Basket.Data.DbContexts
{
    public class BasketDbContext : DbContext, IBasketDbContext
    {
        public BasketDbContext(DbContextOptions<BasketDbContext> options)
                : base(options)
        {
        }

        public DbSet<UserBasket> Baskets { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
