using System.ComponentModel.DataAnnotations;

namespace CouponApi.DTOs
{
    public class MarketingLoginDTO
    {
        [Required] public string? Email { get; set; }
        [Required] public string? Password { get; set; }
    }
}