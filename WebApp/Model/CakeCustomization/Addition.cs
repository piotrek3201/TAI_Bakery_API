using System.Text.Json.Serialization;

namespace WebApp.Model
{
    public class Addition
    {
        public long AdditionId { get; set; }
        public string AdditionName { get; set; } = string.Empty;
        public string AdditionVisual { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Customization>? Customizations { get; set; }
    }
}
