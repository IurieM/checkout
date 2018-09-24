using Basket.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Basket.Data.DbContexts
{
    public interface IBasketDbContext
    {
        DbSet<UserBasket> Baskets { get; set; }

        Task<int> SaveChangesAsync();
    }
}
