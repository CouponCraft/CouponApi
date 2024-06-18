using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CouponApi.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required] public string? Name { get; set; }
        [JsonIgnore] public ICollection<UserRole>? UserRoles { get; set; }
    }
}