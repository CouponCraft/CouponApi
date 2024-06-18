using System.ComponentModel.DataAnnotations;

namespace CouponApi.DTOs
{
    public class CouponHistoryDTO
    {
        [Required] public DateTime? ChangeDate { get; set; }
        [Required] public string? FieldChanged { get; set; }
        [Required] public string? OldValue { get; set; }
        [Required] public string? NewValue { get; set; }
        [Required] public int? CouponId { get; set; }
    }
}