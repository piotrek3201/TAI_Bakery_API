using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApp.Model
{
    public class Glaze
    {
        [Key]
        [Required]
        public long GlazeId { get; set; }
        [Required]
        public string GlazeName { get; set; } = string.Empty;
        [Required]
        public string GlazeColor { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Customization>? Customizations { get; set; }
    }
}
