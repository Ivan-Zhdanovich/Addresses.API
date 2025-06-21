

namespace Addresses.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Republic { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Room { get; set; }
        public Boolean IsActive { get; set; } 
        
    }
}
