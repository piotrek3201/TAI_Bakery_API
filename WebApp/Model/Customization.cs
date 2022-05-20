using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApp.Model
{
    public class Customization
    {
        [Key]
        [Required]
        public long CustomizationId { get; set; }
        //[Required]
        //public long OrderDetailId { get; set; }
        [Required]
        public long SizeId { get; set; }
        [Required]
        public long GlazeId { get; set; }
        [Required]
        public long FillingId { get; set; }
        [Required]
        public long CakeId { get; set; }
        public long AdditionId { get; set; }
        public string? Text { get; set; }

        [JsonIgnore]
        public List<OrderDetail>? OrderDetails { get; set; }
        //[JsonIgnore]
        public Size? Size { get; set; }
        //[JsonIgnore]
        public Glaze? Glaze { get; set; }
        //[JsonIgnore]
        public Filling? Filling { get; set;}
        //[JsonIgnore]
        public Cake? Cake { get; set; }
        //[JsonIgnore]
        public Addition? Addition { get; set; }
    }
}
