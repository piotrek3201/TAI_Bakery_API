using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApp.Model
{
    public class Category
    {
        [Key]
        [Required]
        public long CategoryId { get; set; }
        [Required]
        [MaxLength(20)]
        public string CategoryName { get; set; } = string.Empty;

        //navigation property for EF Core
        [JsonIgnore]
        public List<Product>? Products { get; set;}
    }
}
