using Identity.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ConfigureAuthenticationContext(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.HasKey(x => x.Id);
                user.HasIndex(x => x.Username).IsUnique();
                user.Property(x => x.Password).IsRequired();
            });
        }
    }
}
