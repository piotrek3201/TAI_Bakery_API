using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApp.Model
{
    public class Filling
    {
        [Key]
        [Required]
        public long FillingId { get; set; }
        [Required]
        public string FillingName { get; set; } = string.Empty;
        [Required]
        public string FillingColor { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Customization>? Customizations { get; set; }
    }
}
