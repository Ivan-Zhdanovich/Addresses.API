using Addresses.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Addresses.Domain.Interfaces;
using Addresses.Infrastructure.Persistence;

namespace Addresses.Infrastructure.Repositories
{
    public class AddressRepository(AddressesDbContext dbContext) : IAddressRepository
    {
        private readonly AddressesDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<Address> GetByIdAsync(int id)
        {
            var address = await _dbContext.Addresses.FindAsync(id) ?? throw new KeyNotFoundException();
            return address;
        }

        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            return await _dbContext.Addresses.ToListAsync();
        }

        public async Task AddAsync(Address address)
        {
            _dbContext.Addresses.Add(address);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Address address)

        {
            var addressForUpdate = await this.GetByIdAsync(id) ?? throw new KeyNotFoundException();
            _dbContext.Entry(addressForUpdate).CurrentValues.SetValues(address);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var addressForDelete = await this.GetByIdAsync(id) ?? throw new KeyNotFoundException(); ;
            _dbContext.Addresses.Remove(addressForDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
