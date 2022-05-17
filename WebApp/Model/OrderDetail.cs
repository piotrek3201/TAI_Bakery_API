using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApp.Model
{
    public class OrderDetail
    {
        [Key]
        [Required]
        public long OrderDetailId { get; set; }
        [Required]
        public long OrderId { get; set; }
        [Required]
        public long ProductId { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }

        //navigation properties for EF Core:
        [JsonIgnore]
        public Order? Order { get; set; }
        //[JsonIgnore]
        public Product? Product { get; set; }
    }
}
