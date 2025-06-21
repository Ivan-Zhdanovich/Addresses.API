using Addresses.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addresses.Domain.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAllAsync();
        Task<Address> GetByIdAsync(int id);
        Task AddAsync(Address address);
        Task UpdateAsync(int id, Address updatedAddress);
        Task DeleteAsync(int id);
    }
}
