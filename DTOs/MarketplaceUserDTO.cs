using System.ComponentModel.DataAnnotations;

namespace CouponApi.DTOs
{
    public class MarketplaceUserDTO
    {
        [Required] public string? Username { get; set; }
        [Required] public string? Password { get; set; }
        [Required] public string? Email { get; set; }
    }
}