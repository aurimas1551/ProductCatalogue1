using System.ComponentModel.DataAnnotations;

namespace ProductCatalogue.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
