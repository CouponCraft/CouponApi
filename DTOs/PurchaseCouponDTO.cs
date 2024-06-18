using System.ComponentModel.DataAnnotations;

namespace CouponApi.DTOs
{
    public class PurchaseCouponDTO
    {
        [Required] public int? PurchaseId { get; set; }
        [Required] public int? CouponId { get; set; }
    }
}