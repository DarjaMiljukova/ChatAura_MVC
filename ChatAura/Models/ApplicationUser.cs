using System.ComponentModel.DataAnnotations;

namespace ChatAura.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter your Phonenumber")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
