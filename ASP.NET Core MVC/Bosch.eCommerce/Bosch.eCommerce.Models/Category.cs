using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Bosch.eCommerce.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        
        [Required(ErrorMessage ="Category name is required")]
        [MaxLength(50, ErrorMessage = "Category name cannot exceed 50 chracters!")]
        public string CategoryName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Category Description is a required field!")]
        [MaxLength(200, ErrorMessage = "Description can not exceed 200 characters!")]
        public string Description { get; set; } = string.Empty ;


        public virtual ICollection<Product>? Products { get; set; }
    }
}
