using System.ComponentModel.DataAnnotations;

namespace WebApp.Model
{
    public class Product
    {
        [Key]
        [Required]
        public long ProductId { get; set; }
        [Required]
        public long CategoryId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public double Price { get; set; }
        [Required]
        public bool IsByWeight { get; set; }
        [Required]
        public bool IsCustomizable { get; set; }
    }
}
