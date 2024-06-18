using System.ComponentModel.DataAnnotations;

namespace CouponApi.Models
{
    public class PurchaseProductDTO
    {
        [Required] public int? ProductId { get; set; }
        [Required] public int? PurchaseId { get; set; }
    }
}