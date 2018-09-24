using Catalog.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Catalog.Data.DbContexts
{
    public interface ICatalogDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync();
    }
}
