
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="Contact Name is a required feild")]
        [MaxLength(10,ErrorMessage ="Length of 10 characters exceeded")]
        public string ContactName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact Name is a required feild")]
        [MaxLength(10, ErrorMessage = "Length of 10 characters exceeded")]
        public string City { get; set; } = string.Empty ;

    }
}
