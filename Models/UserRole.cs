using System.ComponentModel.DataAnnotations;

namespace CouponApi.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        [Required] public int? MarketingUserId { get; set; }
        public MarketingUser? User { get; set; }
        [Required] public int? RoleId { get; set; }
        public Role? Role { get; set; }
    }
}