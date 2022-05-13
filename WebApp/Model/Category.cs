using System.ComponentModel.DataAnnotations;

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
    }
}
