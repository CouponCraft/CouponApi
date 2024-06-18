

using System.ComponentModel.DataAnnotations;

namespace CouponApi.Models
{
    public class PurchaseProduct
    {
        public int Id { get; set; }
        [Required] public int? ProductId { get; set; }
        public Product? Product { get; set; }
        [Required] public int? PurchaseId { get; set; }
        public Purchase? Purchase { get; set; }
    }
}