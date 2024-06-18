using System.ComponentModel.DataAnnotations;

namespace CouponApi.DTOs
{
    public class PurchaseDTO
    {
        [Required] public DateTime? Date { get; set; }
        [Required] public decimal? Amount { get; set; }
        [Required] public int? UserId { get; set; }
    }
}