using System.ComponentModel.DataAnnotations;

namespace ChatAura.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите номер телефона")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
