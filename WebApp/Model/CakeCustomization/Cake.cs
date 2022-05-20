using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApp.Model
{
    public class Cake
    {
        [Key]
        [Required]
        public long CakeId { get; set; }
        [Required]
        public string CakeName { get; set; } = string.Empty;
        [Required]
        public string CakeColor { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Customization>? Customizations { get; set; }
    }
}
