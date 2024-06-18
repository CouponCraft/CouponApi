using System.ComponentModel.DataAnnotations;

namespace CouponApi.Models
{
    public class CouponHistory
    {
        public int Id { get; set; }
        [Required] public DateTime? ChangeDate { get; set; }
        [Required] public string? FieldChanged { get; set; }
        [Required] public string? OldValue { get; set; }
        [Required] public string? NewValue { get; set; }
        [Required] public int? CouponId { get; set; }
        public Coupon? Coupon { get; set; }
    }
}