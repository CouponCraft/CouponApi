using System.ComponentModel.DataAnnotations;

namespace CouponApi.Models
{
    public class PurchaseCoupon
    {
        public int Id { get; set; }
        [Required] public int? PurchaseId { get; set; }
        public Purchase? Purchase { get; set; }
        [Required] public int? CouponId { get; set; }
        public Coupon? Coupon { get; set; }
    }
}