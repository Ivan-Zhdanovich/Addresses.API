using Addresses.Domain.Entities;
using Addresses.Infrastructure.Persistence;


namespace Addresses.Infrastructure.Seeders
{
    internal class AddressSeeder(AddressesDbContext dbContext) : IAddressSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Addresses.Any())
                {
                    var addresses = GetAddresses();
                    dbContext.Addresses.AddRange(addresses);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<Address> GetAddresses()
        {
            List<Address> addresses = [

        new Address()
        {
            Republic = "Республика Беларусь",

            Region = "Минская область",

            City = "Минск",

            Street = "Антоновская",

            House = "30",

            Room  = "28",

            IsActive = true
        },
         new Address()
        {
            Republic = "Республика Беларусь",

            Region = "Минская область",

            City = "Минск",

            Street = "Притыцкого",

            House = "18",

            Room  = "25",

            IsActive = true
        },
            ];

            return addresses;
        }

    }
}

