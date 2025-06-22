using Addresses.Domain.Entities;
using Addresses.Infrastructure.DTOs;
using Addresses.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Addresses.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController(AddressesDbContext addressesDbContext) : ControllerBase
    {
        private readonly AddressesDbContext _addressesDbContext = addressesDbContext;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
           
            return await _addressesDbContext.Addresses.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddressById(int id)
        {
         
            var address = await _addressesDbContext.Addresses.FindAsync(id);
            if (address is null)
            {
                return NotFound();
            }
            return address;
        }

        [HttpPost]
        public async Task<ActionResult<Address>> CreateAddress(Address address)
        {
            _addressesDbContext.Addresses.Add(address);
            await _addressesDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAddressById), new { id = address.Id }, address);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Address>> UpdateAddress(int id, Address updatedAddress)
        {
            var address = await _addressesDbContext.Addresses.FindAsync(id);
            if (address is null)
            {
                return NotFound();
            }

            address.Id = address.Id;
            address.Republic = updatedAddress.Republic;
            address.Region = updatedAddress.Region;
            address.City = updatedAddress.City;
            address.Street = updatedAddress.Street;
            address.House = updatedAddress.House;
            address.Room = updatedAddress.Room;
            await _addressesDbContext.SaveChangesAsync();
            return Ok();

        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Address>> UpdateAddressProperties(int id, AddressUpdateDto addressUpdate)
        {

            var address = await _addressesDbContext.Addresses.FindAsync(id);
            if (address is null)
            {
                return NotFound();
            }

            address.Region = addressUpdate.Region ?? address.Region;
            address.City = addressUpdate.City ?? address.City;
            address.Street = addressUpdate.Street ?? address.Street;
            address.House = addressUpdate.House ?? address.House;
            address.Room = addressUpdate.Room ?? address.Room;
            await _addressesDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> DeleteAddress(int id)
        {
           
            var address = await _addressesDbContext.Addresses.FindAsync(id);
            if (address is null)
            {
                return NotFound();
            }
            _addressesDbContext.Addresses.Remove(address);
            await _addressesDbContext.SaveChangesAsync();
            return NoContent();

        }

    }
}
