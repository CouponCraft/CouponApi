using System.ComponentModel.DataAnnotations;

namespace CouponApi.DTOs
{
    public class ProductDTO
    {
        [Required] public string? Name { get; set; }
        [Required] public string? Description { get; set; }
        [Required] public decimal? Price { get; set; }
        [Required] public int? CategoryId { get; set; }
    }
}