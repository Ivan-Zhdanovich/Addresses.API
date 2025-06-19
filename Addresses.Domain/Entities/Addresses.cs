

namespace Addresses.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Republic { get; set; } = default!;
        public string Region { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string House { get; set; } = default!;
        public string Room { get; set; } = default!;
        public Boolean IsActive { get; set; }

    }
}
