using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CouponApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required] public string? Name { get; set; }
        [Required] public string? Description { get; set; }
        [Required] public decimal? Price { get; set; }
        [Required] public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        [JsonIgnore] public ICollection<PurchaseProduct>? PurchaseProducts { get; set; }
    }
}