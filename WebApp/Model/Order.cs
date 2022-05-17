using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApp.Model
{
    public class Order
    {
        [Key]
        [Required]
        public long OrderId { get; set; }
        [Required]
        public string CustomerEmail { get; set; } = string.Empty;
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        [Required]
        public string CustomerPhone { get; set; } = string.Empty;
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        public decimal OrderValue { get; set; }

        //navigation property for EF Core:
        //[JsonIgnore]
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
