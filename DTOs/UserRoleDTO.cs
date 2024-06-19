using System.ComponentModel.DataAnnotations;

namespace CouponApi.DTOs
{
    public class UserRoleDTO
    {
        [Required] public int? MarketingUserId { get; set; }
        [Required] public int? RoleId { get; set; }
    }
}