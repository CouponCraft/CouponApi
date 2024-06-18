using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CouponApi.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        [Required] public string? Name { get; set; }
        [Required] public string? Description { get; set; }
        [Required] public DateTime? StartDate { get; set; }
        [Required] public DateTime? EndDate { get; set; }
        [Required] public string? DiscountType { get; set; }
        [Required] public decimal? DiscountValue { get; set; }
        [Required] public int? UsageLimit { get; set; }
        [Required] public decimal? MinPurchaseAmount { get; set; }
        [Required] public decimal? MaxPurchaseAmount { get; set; }
        [Required] public string? Status { get; set; }
        [Required] public int? CreatedBy { get; set; }
        public MarketingUser? User { get; set; }
        [JsonIgnore] public ICollection<CouponUsage>? CouponUsages { get; set; }
        [JsonIgnore] public ICollection<PurchaseCoupon>? PurchaseCoupons { get; set; }
        [JsonIgnore] public ICollection<CouponHistory>? CouponHistories { get; set; }
    }
}