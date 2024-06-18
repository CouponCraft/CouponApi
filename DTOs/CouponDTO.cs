using System.ComponentModel.DataAnnotations;

namespace CouponApi.DTOs
{
    public class CouponDTO
    {
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
    }
}