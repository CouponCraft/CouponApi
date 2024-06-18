using System.ComponentModel.DataAnnotations;

namespace CouponApi.DTOs
{
    public class CouponUsageDTO
    {
        [Required] public DateTime? UsageDate { get; set; }
        [Required] public int? CouponId { get; set; }
        [Required] public int? UserId { get; set; }
    }
}