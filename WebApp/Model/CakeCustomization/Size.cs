using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApp.Model
{
    public class Size
    {
        [Key]
        [Required]
        public long SizeId { get; set; }
        [Required]
        public int Diameter { get; set; }

        [JsonIgnore]
        public List<Customization>? Customizations { get; set; }
    }
}
