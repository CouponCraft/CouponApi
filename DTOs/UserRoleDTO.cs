using System.ComponentModel.DataAnnotations;

namespace CouponApi.DTOs
{
    public class UserRoleDTO
    {
        [Required] public int? UserId { get; set; }
        [Required] public int? RoleId { get; set; }
    }
}