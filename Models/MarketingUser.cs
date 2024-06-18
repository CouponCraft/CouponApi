using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CouponApi.Models
{
    public class MarketingUser
    {
        public int Id { get; set; }
        [Required] public string? Username { get; set; }
        [Required] public string? Password { get; set; }
        [Required] public string? Email { get; set; }
        [JsonIgnore] public ICollection<Coupon>? Coupons { get; set; }
        [JsonIgnore] public ICollection<UserRole>? UserRoles { get; set; }
    }
}