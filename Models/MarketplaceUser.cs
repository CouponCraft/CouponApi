using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CouponApi.Models
{
    public class MarketplaceUser
    {
        public int Id { get; set; }
        [Required] public string? Username { get; set; }
        [Required] public string? Password { get; set; }
        [Required] public string? Email { get; set; }
        [JsonIgnore] public ICollection<CouponUsage>? CouponUsages { get; set; }
        [JsonIgnore] public ICollection<Purchase>? Purchases { get; set; }
    }
}