using Addresses.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Addresses.Infrastructure.Persistence
{
    internal class AddressesDbContext(DbContextOptions<AddressesDbContext> options) 
        : IdentityDbContext<User>(options)
    {
        internal DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql();
        }
    }
}
