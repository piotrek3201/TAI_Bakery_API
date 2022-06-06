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
        [MaxLength(200)]
        [EmailAddress]
        public string CustomerEmail { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; } = string.Empty;
        [Required]
        [MaxLength(16)]
        [Phone]
        public string CustomerPhone { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string CustomerAddress { get; set; } = string.Empty;
        [Required]
        [MaxLength(30)]
        public string CustomerCity { get; set; } = string.Empty;
        [Required]
        [MaxLength(10)]
        public string CustomerPostalCode { get; set; } = string.Empty;
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        public DateTime DeliveryDate { get; set; } = DateTime.Now.AddDays(1);
        [Required]
        public decimal OrderValue { get; set; }
        [Required]
        public bool IsFinished { get; set; } = false;
        [Required]
        public bool SelfPickUp { get; set; } = false;

        //navigation property for EF Core:
        //[JsonIgnore]
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
