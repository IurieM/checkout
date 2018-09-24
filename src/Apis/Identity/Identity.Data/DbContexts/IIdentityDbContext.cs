using Identity.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Identity.Data.DbContexts
{
    public interface IIdentityDbContext
    {
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync();
    }
}
