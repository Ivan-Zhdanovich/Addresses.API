
namespace Addresses.Infrastructure.DTOs
{
    public class AddressUpdateDto
    {
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? House { get; set; }
        public string? Room { get; set; }
        public Boolean? IsActive { get; set; }
    }
}
