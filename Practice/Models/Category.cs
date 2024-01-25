using System.ComponentModel.DataAnnotations;

namespace Practice.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(1, 500)]
        public int DisplayOrder { get; set; }
    }
}
