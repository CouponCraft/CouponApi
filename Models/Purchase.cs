using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CouponApi.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        [Required] public DateTime? Date { get; set; }
        [Required] public decimal? Amount { get; set; }
        [Required] public int? UserId { get; set; }
        public MarketplaceUser? User { get; set; }
        [JsonIgnore] public ICollection<PurchaseProduct>? PurchaseProducts { get; set; }
        [JsonIgnore] public ICollection<PurchaseCoupon>? PurchaseCoupons { get; set; }
    }
}