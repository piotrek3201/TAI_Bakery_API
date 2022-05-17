using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApp.Model
{
    public class Product
    {
        [Key]
        [Required]
        public long ProductId { get; set; }
        [Required]
        public long CategoryId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool IsByWeight { get; set; }
        [Required]
        public bool IsCustomizable { get; set; } = false;
        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        //navigation properties for EF Core
        //[JsonIgnore]
        public Category? Category { get; set; }
        [JsonIgnore]
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
