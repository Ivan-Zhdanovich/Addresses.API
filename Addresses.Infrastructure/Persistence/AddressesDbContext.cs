using Addresses.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Addresses.Infrastructure.Persistence
{
    public class AddressesDbContext(DbContextOptions<AddressesDbContext> options) 
        : DbContext(options)
    
    {
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql();
        }
    }
}
