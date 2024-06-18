using System.ComponentModel.DataAnnotations;

namespace CouponApi.Models
{
    public class CouponUsage
    {
        public int Id { get; set; }
        [Required] public DateTime? UsageDate { get; set; }
        [Required] public int? CouponId { get; set; }
        public Coupon? Coupon { get; set; }
        [Required] public int? UserId { get; set; }
        public MarketplaceUser? User { get; set; }
    }
}