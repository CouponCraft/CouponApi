using System.ComponentModel.DataAnnotations;

namespace CouponApi.DTOs
{
    public class CategoryDTO
    {
        [Required] public string? Name { get; set; }
    }
}