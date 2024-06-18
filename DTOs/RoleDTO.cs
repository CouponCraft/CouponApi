using System.ComponentModel.DataAnnotations;

namespace CouponApi.DTOs
{
    public class RoleDTO
    {
        [Required] public string? Name { get; set; }
    }
}